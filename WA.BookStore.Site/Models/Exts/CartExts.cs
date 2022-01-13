using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.Exts
{
	public static partial class CartExts
	{
		public static CartEntity ToEntity(this Cart cart)
		{
			var items = cart.CartItems.Select(x => x.ToItemEntity()).ToList();

			return new CartEntity(cart.Id, cart.MemberAccount, items);
		}
	}
}