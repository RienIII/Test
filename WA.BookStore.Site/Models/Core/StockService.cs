using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Core.Interfaces;
using WA.BookStore.Site.Models.DTOs;

namespace WA.BookStore.Site.Models.Core
{
	public class StockService : IStockService
	{
		private readonly IStockRepository repository;

		public StockService(IStockRepository repo)
		{
			this.repository = repo;
		}
		public void Deduct(DeductStockInfo[] info)
		{
			// Select 是轉型，再說一次
			var data = info
				.Select(x=>(x.ProductId, x.Qty * -1))
				.ToArray();

			repository.Update(data);
		}

		public void Revise(ReviseStockInfo[] info)
		{
			var data = info
				.Select(x => (x.ProductId, x.Qty))
				.ToArray();

			repository.Update(data);
		}
	}
}