using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.BookStore.Site.Models.DTOs;

namespace WA.BookStore.Site.Models.Core.Interfaces
{
	public interface IOrderService
	{
		/// <summary>
		/// 新訂單會觸發事件，扣庫存
		/// </summary>
		event Action<IOrderService, int> OrderCreated;

		/// <summary>
		/// 退貨申請通過，會觸發事件
		/// 加庫存
		/// </summary>
		event Action<IOrderService, int> RefundRequestByCustomer;

		/// <summary>
		/// 結帳，建立一筆新訂單
		/// </summary>
		/// <param name="request"></param>
		void PlaceOrder(CreateOrderRequest request);

		/// <summary>
		/// 只有客戶本人才能提出退訂申請；訂單必須符合退訂條件才行
		/// 訂單必須還沒完成出貨或出貨7天內，才允許由使用者退貨；會註記 Order.RequestReund
		/// 如果沒有出貨可以直接退訂；若已出貨，則需後台進行審核
		/// </summary>
		/// <param name="account"></param>
		/// <param name="orderId"></param>
		void Refund(string account, int orderId);
	}
}
