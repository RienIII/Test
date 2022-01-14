using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Core.Interfaces;
using WA.BookStore.Site.Models.DTOs;
using WA.BookStore.Site.Models.Entities;
using WA.BookStore.Site.Models.ValueObjects;

namespace WA.BookStore.Site.Models.Core
{
	public class CartService : ICartService
	{
		public event Action<ICartService, string> RequestCheckout;

		// 建構子 不可能一次寫齊，可以之後慢慢加
		private readonly ICartRepository cartRepository;
		private readonly IProductRepository productRepository;
		private readonly ICustomerRepository customerRepository;
		public CartService(ICartRepository cartRepo, IProductRepository productRepo, ICustomerRepository customerRepo)
		{
			this.cartRepository = cartRepo;
			this.productRepository = productRepo;
			this.customerRepository = customerRepo;
		}

		// 加protected是不想讓外界呼叫的到，virtual是如果有子類別，就可以複寫他
		// 複寫的原因是:可以增加功能，或是不想要觸發事件等
		protected virtual void OnCheckout(string account)
		{
			if(RequestCheckout != null)
			{
				RequestCheckout(this, account);
			}
		}

		private ShippingInfo _shippingInfo;
		public void Checkout(string account, ShippingInfo shippingInfo)
		{
			if(string.IsNullOrEmpty(account))throw new ArgumentNullException(nameof(account));
			if (shippingInfo == null) throw new Exception("收件人不能是null");

			this._shippingInfo = shippingInfo; // 先暫存，ToCreateOrderRequest會用到

			OnCheckout(account); // 觸發OnCheckout事件
		}
		public CartEntity Current(string account)
		{
			if (!cartRepository.IsExist(account))
			{
				return cartRepository.CreateNewCart(account);
			}

			return cartRepository.Lord(account);
		}
		public void AddItem(string account, int productId, int qty = 1)
		{
			CartEntity cart = Current(account);

			var product = productRepository.Lord(productId, true);

			CartProductEntity productEntity = new CartProductEntity { 
				Id = productId, 
				Name = product.Name, 
				Price = product.Price 
			};

			cart.AddItem(productEntity, qty);

			cartRepository.Save(cart); // 記得要存檔，因為 AddItme 沒有存到資料庫，切換到別的網頁會抓不到
		}
		public void UpdateItem(string account, int productId, int newQty)
		{
			var cart = Current(account);

			cart.UpdateQty(productId, newQty);

			cartRepository.Save(cart); // 記得要存檔，因為 UpdateItem 沒有存到資料庫，切換到別的網頁會抓不到
		}
		public void RemoveItem(string account, int productId)
		{
			var cart = Current(account);

			cart.RemoveItem(productId);

			cartRepository.Save(cart); // 記得要存檔，因為 RemoveItem 沒有存到資料庫，切換到別的網頁會抓不到
		}
		public void EmptyCart(string account)
		{
			cartRepository.EmptyCart(account);
		}
		public DeductStockInfo[] GetDeductStockInfo(CartEntity cart)
		{
			return cart.GetItem()
				.Select(x=>new DeductStockInfo { 
					ProductId = x.Product.Id, 
					Qty = x.Qty })
				.ToArray();
		}
		public CreateOrderRequest ToCreateOrderRequest(CartEntity cart)
		{
			List<CreateOrderItem> items = cart.GetItem()
				.Select(x => new CreateOrderItem
				{
					ProductId = x.Product.Id,
					ProductName = x.Product.Name,
					Price = x.Product.Price,
					Qty = x.Qty
				})
				.ToList();

			return new CreateOrderRequest
			{
				CustomerId = customerRepository.GetCustormerId(cart.Account),
				Items = items,
				ShippingInfo = _shippingInfo
			};
		}
	}
}