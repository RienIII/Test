using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BookStore.Site.Models.DTOs
{
	/// <summary>
	/// 取消訂單時，要增加庫存量
	/// </summary>
	public class ReviseStockInfo
	{
		public int ProductId { get; set; }
		public int Qty { get; set; }
	}
}