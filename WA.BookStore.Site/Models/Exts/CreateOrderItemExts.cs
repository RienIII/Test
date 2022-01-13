using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.DTOs;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.Exts
{
	public static partial class CreateOrderItemExts
	{
		public static OrderItem ToEF(this CreateOrderItem item)
		{
			return new OrderItem
			{
				ProductId = item.ProductId,
				Price = item.Price,
				ProductName = item.ProductName,
				Qty = item.Qty,
				SubTotal = item.SubTotal
			};
		}
	}
}