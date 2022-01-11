using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Core.Interfaces;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.Core
{
	public class ProductService
	{
		private readonly IProductRepository repository;

		public ProductService(IProductRepository repo)
		{
			repository = repo;
		}

		/// <summary>
		/// 尋找資料，因為沒有商業邏輯，所以寫在Controller直接呼叫也是可以的
		/// 裡面的程式的第三個參數已經寫死，只找上架商品，不要讓Controller有機會設定
		/// 因為寫Controller的人沒有寫Core的人要求高，沒有必要傳入參數時決定true或是false
		/// 下面的Lord method也是一樣
		/// </summary>
		/// <param name="categoryId"> 先埋查詢條件 </param>
		/// <param name="productName"> 先埋查詢條件 </param>
		/// <returns></returns>
		public IEnumerable<ProductEntity> SearchAvtiveProduct(int categoryId, string productName)
		{
			return repository.Search(categoryId, productName, true);
		}
		public ProductEntity LordAvtiveProduct(int productId)
		{
			return repository.Lord(productId, true);
		}
	}
}