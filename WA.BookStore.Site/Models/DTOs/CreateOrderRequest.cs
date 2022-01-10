using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.ValueObjects;

namespace WA.BookStore.Site.Models.DTOs
{
	/// <summary>
	/// 新增訂單總檔
	/// </summary>
	public class CreateOrderRequest
	{
		public int CustomerId { get; set; }
		public List<CreateOrderItem> Items { get; set; }
		public int Total
		{
			get => Items.Sum(x => x.SubTotal);
		}
		public ShippingInfo ShippingInfo { get; set; }
	}
}