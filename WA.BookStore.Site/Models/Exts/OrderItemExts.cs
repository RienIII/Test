using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.Exts
{
	public static partial class OrderItemExts
	{
		public static OrderItemEntity ToEntity(this OrderItem item)
		{
			return new OrderItemEntity(item.Id, item.Product.ToOrderProductEntity(), item.Qty);
		}
	}
}