using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WA.BookStore.Site.Models.Core.Interfaces;
using WA.BookStore.Site.Models.DTOs;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Entities;
using WA.BookStore.Site.Models.Exts;

namespace WA.BookStore.Site.Models.Infrastructures.Repositories
{
	public class OrderRepository: IOrderRepository
	{
		private AppDbContext db;
		public OrderRepository(AppDbContext dataBase)
		{
			this.db = dataBase;
		}

		public int Create(CreateOrderRequest request)
		{
			Order order =request.ToEF();

			db.Orders.Add(order);
			db.SaveChanges();

			return order.Id;
		}

		public OrderEntity Load(int customerId)
		{
			return db.Orders
				.AsNoTracking()
				.Include(x=>x.OrderItems.Select(x2=>x2.Product))
				.Include(x=>x.Member)
				.SingleOrDefault(x=>x.MemberId==customerId).ToEntity();
		}

		public void RefundByCustomer(int orderId)
		{
			var order = db.Orders.Find(orderId);

			if (order == null) throw new Exception("沒有這筆訂單");

			order.RequestRefund = true;
			order.RequestRefundTime = DateTime.Now;

			db.SaveChanges();
		}

		public IEnumerable<OrderEntity> Search(string account, DateTime? startTime, DateTime? endTime)
		{
			var query = db.Orders
				.AsNoTracking()
				.Include(x => x.OrderItems.Select(x2 => x2.Product))
				.Include(x => x.Member)
				.Where(x => x.Member.Account == account);

			if(startTime.HasValue)query.Where(x=>x.CreateTime >= startTime.Value);
			if(endTime.HasValue)query.Where(x=>x.CreateTime <= endTime.Value);

			query = query.OrderByDescending(x => x.Id);

			return query.ToList().Select(x=>x.ToEntity());
		}
	}
}