using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Core.Interfaces;
using WA.BookStore.Site.Models.EFModels;

namespace WA.BookStore.Site.Models.Infrastructures.Repositories
{
	public class StockRepository : IStockRepository
	{
		private readonly AppDbContext db;
		public StockRepository()
		{
			this.db = new AppDbContext();
		}
		public StockRepository(AppDbContext dataBase)
		{
			this.db = dataBase;
		}

		// 傳入的值已經決定正負數，是增減庫存不是更新庫存
		public void Update((int productId, int qty)[] info)
		{
			if (info == null || info.Length == 0) return;

			int[]productIds = info.Select(x=>x.productId).ToArray();

			var products = db.Products.Where(x => productIds.Contains(x.Id)).ToList();

			foreach (var product in products)
			{
				product.Stock += info.Single(x => x.productId == product.Id).qty;
			}

			db.SaveChanges();
		}
	}
}