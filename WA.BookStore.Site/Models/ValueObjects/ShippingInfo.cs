using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BookStore.Site.Models.ValueObjects
{
	/// <summary>
	/// 收件者資訊
	/// </summary>
	public class ShippingInfo
	{
		public string Receiver { get; set; }
		public string Address { get; set; }
		public string CellPhone { get; set; }
	}
}