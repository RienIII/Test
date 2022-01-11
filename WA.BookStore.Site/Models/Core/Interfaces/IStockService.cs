using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.BookStore.Site.Models.DTOs;

namespace WA.BookStore.Site.Models.Core.Interfaces
{
	/// <summary>
	/// 前台異動庫存量時會用到，像是結帳
	/// 傳進來的數量是正數，在method裡面才決定是增加還是減少庫存
	/// </summary>
	public interface IStockService
	{
		/// <summary>
		/// 下訂單，扣庫存量
		/// </summary>
		/// <param name="info"></param>
		void Deduct(DeductStockInfo[] info);

		/// <summary>
		/// 取消時，加回庫存量
		/// </summary>
		/// <param name="info"></param>
		void Revise(ReviseStockInfo[] info);

	}
}
