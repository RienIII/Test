using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.Exts
{
	public static partial class CartItemEntityExts
	{
		public static CartItem ToEF(this CartItemEntity entity, int id)
		{
			return new CartItem
			{
				Id = entity.Id,
				CartId = id,
				ProductId = entity.Product.Id,
				Qty = entity.Qty
			};
		}
	}
}