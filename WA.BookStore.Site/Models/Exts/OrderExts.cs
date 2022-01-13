using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Entities;
using WA.BookStore.Site.Models.ValueObjects;

namespace WA.BookStore.Site.Models.Exts
{
	public static partial class OrderExts
	{
		public static OrderEntity ToEntity(this Order order)
		{
			if (order == null) return null;

			List<OrderItemEntity>items = order.OrderItems.Select(x=>x.ToEntity()).ToList();

			return new OrderEntity(order.Id, order.Member.Id, order.CreateTime, items, order.ToShippingInfo())
			{
				CustomerAccount = order.Member.Account,
				Status = order.Status,
				RequestRefund = order.RequestRefund,
				RequestRefunTime = order.RequestRefundTime
			};
		}
		public static ShippingInfo ToShippingInfo(this Order sourse)
		{
			return new ShippingInfo
			{
				Receiver = sourse.Receiver,
				Address = sourse.Address,
				CellPhone = sourse.CellPhone
			};
		}
	}
}