using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.Exts
{
	public static partial class CartItemExts
	{
		public static CartItemEntity ToItemEntity(this CartItem item)
		{
			var productItem = item.Product.ToCartProductEntity();

			return new CartItemEntity(productItem, item.Qty) { Id = item.Id };
		}
	}
}