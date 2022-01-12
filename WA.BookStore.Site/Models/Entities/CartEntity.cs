using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Infrastructures;
using WA.BookStore.Site.Models.ValueObjects;

namespace WA.BookStore.Site.Models.Entities
{
	public class CartEntity
	{
		// 如果購物沒有購物車，則新增一個購物車
		public CartEntity(int Id, string account)
		{
			this.Id = Id;
			this.Account = account;
			this.Items = new List<CartItemEntity>();
		}

		// 如果已經有購物車，則新增一個商品項目
		public CartEntity(int Id, string account, List<CartItemEntity> item)
		{
			this.Id = Id;
			this.Account = account;
			this.Items = item;
		}
		public int Id { get; set; }

		private string _Account;
		public string Account
		{
			get => _Account;
			set
			{
				new DataValidator<string>(value, "帳號").RequiredString();
				_Account = value;
			}
		}

		// 購物車明細
		private List<CartItemEntity> Items;

		public int Total
		{
			get => Items == null || Items.Count == 0 ? 0 : Items.Sum(x=>x.SubTotal);
		}

		// 結帳時，如果沒有項目就不給結帳
		public bool AllowCheckout
		{
			get => Items != null && Items.Count > 0;
		}

		// 去得收件者資訊
		public ShippingInfo ShippingInfo { get; set; }

		public void AddItem(CartProductEntity product, int qty)
		{
			if(product == null)throw new ArgumentNullException(nameof(product));
			if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));

			var item = Items.SingleOrDefault(x => x.Product.Id == product.Id);

			if(item == null)
			{
				var cartItem = new CartItemEntity(product, qty);
				Items.Add(cartItem);
			}
			else
			{
				item.Qty += qty;
			}
		}

		/// <summary>
		/// 刪除購物車商品項目
		/// </summary>
		/// <param name="productId">直接指定就好</param>
		public void RemoveItem(int productId)
		{
			var item = Items.SingleOrDefault(x => x.Product.Id == productId);
			if (item == null) return;

			Items.Remove(item);
		}

		/// <summary>
		/// 更新商品項目數量
		/// </summary>
		/// <param name="productId">要更新數量商品</param>
		/// <param name="newQty">如果小於0，會直接刪除該項目</param>
		public void UpdateQty(int productId, int newQty)
		{
			if(newQty <= 0)
			{
				RemoveItem(productId);
				return;
			}

			var item = Items.SingleOrDefault(x => x.Product.Id == productId);
			if( item == null) return;

			item.Qty = newQty;
		}

		/// <summary>
		/// 應該建一個class把複製一份資料給別人，這樣別人怎麼改是他的事，原始資料都不會改變
		/// </summary>
		/// <returns></returns>
		public IEnumerable<CartItemEntity> GetItem() 
			=> this.Items;
			
	}
}