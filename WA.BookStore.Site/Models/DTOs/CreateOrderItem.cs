using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BookStore.Site.Models.DTOs
{
	/// <summary>
	/// 訂單明細，從Cart傳到Order
	/// </summary>
	public class CreateOrderItem
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int Price { get; set; }
		public int Qty { get; set; }
		public int SubTotal
		{
			get => Price * Qty;
		}
	}
}