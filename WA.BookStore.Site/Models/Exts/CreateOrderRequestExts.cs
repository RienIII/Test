using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.DTOs;
using WA.BookStore.Site.Models.EFModels;

namespace WA.BookStore.Site.Models.Exts
{
	public static partial class CreateOrderRequestExts
	{
		public static Order ToEF(this CreateOrderRequest request)
		{
			return new Order
			{
				MemberId = request.CustomerId,
				CreateTime = DateTime.Now,
				Status = 1,
				Total = request.Total,
				Receiver = request.ShippingInfo.Receiver,
				Address = request.ShippingInfo.Address,
				CellPhone = request.ShippingInfo.CellPhone,
				OrderItems = request.Items.Select(x => x.ToEF()).ToList(),
			};
		}
	}
}