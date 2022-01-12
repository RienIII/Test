using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Core.Interfaces;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Entities;
using WA.BookStore.Site.Models.Exts;

namespace WA.BookStore.Site.Models.Infrastructures.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext db;
		public ProductRepository()
		{
			this.db = new AppDbContext();
		}
		public ProductEntity Lord(int productId, bool? status)
		{
			IEnumerable<Product> query = db.Products.AsNoTracking().Where(x => x.Id == productId);

			// HasValue會看這邊有沒有傳進來東西，因為有問號可傳可不傳
			if(status.HasValue) query = query.Where(x=>x.Status == status.Value);
			var product = query.SingleOrDefault();

			return product == null ? null : product.ToEntity();
		}

		public IEnumerable<ProductEntity> Search(int? categoryId, string productName, bool? status)
		{
			IEnumerable<Product> query = db.Products.AsNoTracking();

			if(categoryId.HasValue) query = query.Where(x=>x.CategoryId == categoryId.Value);
			if(string.IsNullOrEmpty(productName)) query = query.Where(x => x.Name == productName);
			if(status.HasValue)query = query.Where(x=>x.Status == status.Value);

			var products = query.OrderBy(x=>x.Name);

			return products == null ? null : products.Select(x=>x.ToEntity());
		}
	}
}