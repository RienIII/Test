using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.Core.Interfaces
{
	public interface ICartRepository
	{
		/// <summary>
		/// 看客戶的購物車是否存在
		/// </summary>
		/// <param name="account">其實用ID找更快</param>
		/// <returns></returns>
		bool IsExist(string account);

		/// <summary>
		/// 如果沒有購物車，就新建一個
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		CartEntity CreateNewCart(string account);

		/// <summary>
		/// 找購物車，如果有就回傳，如果沒有就傳回異常
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		CartEntity Lord(string account);

		/// <summary>
		/// 刪除購物車
		/// </summary>
		/// <param name="account"></param>
		void EmptyCart(string account);

		/// <summary>
		/// 把購物車存到資料庫，會比較麻煩
		/// 因為有購物車和購物車明細要一起存檔
		/// </summary>
		/// <param name="cart"></param>
		void Save(CartEntity cart);

	}
}
