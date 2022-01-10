using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BookStore.Site.Models.DTOs
{
	/// <summary>
	/// 新增訂單時，要扣除庫存量
	/// </summary>
	public class DeductStockInfo
	{
		public int ProductId { get; set; }
		public int Qty { get; set; }
	}
}