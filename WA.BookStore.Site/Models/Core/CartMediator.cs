using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Core.Interfaces;
using WA.BookStore.Site.Models.DTOs;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.Core
{
	public class CartMediator
	{
		private readonly ICartService cartService;
		private readonly IOrderService orderService;
		private readonly IStockService stockService;

		public CartMediator(ICartService cart, IOrderService order, IStockService stock)
		{
			this.cartService = cart;
			this.orderService = order;
			this.stockService = stock;

			cartService.RequestCheckout += CartService_RequestCheckout;
		}

		private void CartService_RequestCheckout(ICartService sender, string account)
		{
			CartEntity cart = cartService.Current(account);

			orderService.PlaceOrder(cartService.ToCreateOrderRequest(cart));

			stockService.Deduct(cartService.GetDeductStockInfo(cart));

			cartService.EmptyCart(account);
		}
	}
}