using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Core.Interfaces;
using WA.BookStore.Site.Models.DTOs;

namespace WA.BookStore.Site.Models.Core
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository repository;
		public event Action<IOrderService, int> OrderCreated;
		public event Action<IOrderService, int> RefundRequestByCustomer;

		public OrderService(IOrderRepository repo)
		{
			this.repository = repo;
		}
		protected virtual void OnOrderCreated(int orderId)
		{
			if(OrderCreated != null)
			{
				OrderCreated(this, orderId);
			}
		}
		protected virtual void OnRefundRequestByCustomer(int orderId)
		{
			if(RefundRequestByCustomer != null)
			{
				RefundRequestByCustomer(this, orderId);
			}
		}
		public void PlaceOrder(CreateOrderRequest request)
		{
			int orderId = repository.Create(request);

			OnOrderCreated(orderId);
		}

		public void Refund(string account, int orderId)
		{
			var orderEntity = repository.Load(orderId);

			if (orderEntity == null) throw new Exception("找不到紀錄");

			if (string.Compare(orderEntity.CustomerAccount, account) != 0) throw new Exception("不是你的訂單");

			if (!orderEntity.AllowRefund) throw new Exception("無法進行退訂");

			repository.RefundByCustomer(orderId);

			OnRefundRequestByCustomer(orderId);
		}
	}
}