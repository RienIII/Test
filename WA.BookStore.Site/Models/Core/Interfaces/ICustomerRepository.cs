using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.Core.Interfaces
{

	/// <summary>
	/// 對前台，買家是Customer，與Member是不一樣的，所以額外寫一個
	/// </summary>
	public interface ICustomerRepository
	{
		/// <summary>
		/// 有權限在本網站購物的會員才會傳回true
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		bool IsExist(string account);

		/// <summary>
		/// 有權限在本網站購物的會員才會傳回 id
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		int GetCustormerId(string account);

		/// <summary>
		/// 有權限在本網站購物的會員才會傳回物件
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		CustomerEntity Lord(string account);
	}
}
