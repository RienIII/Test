using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.BookStore.Site.Models.DTOs;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.Core.Interfaces
{
	public interface IOrderRepository
	{
		/// <summary>
		/// 建立一筆新紀錄及明細
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		int Create(CreateOrderRequest request);

		/// <summary>
		/// 客戶提出退訂申請
		/// </summary>
		/// <param name="customerId"></param>
		void RefundByCustomer(int customerId);

		/// <summary>
		/// 傳回訂單
		/// </summary>
		/// <param name="customerId"></param>
		/// <returns></returns>
		OrderEntity Load(int customerId);

		IEnumerable<OrderEntity> Search(string account, DateTime? startTime, DateTime? endTime);
	}
}
