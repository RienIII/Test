using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.Core.Interface
{
	public interface IProductRepository
	{
		/// <summary>
		/// 篩選商品
		/// </summary>
		/// <param name="categoryId"> 根據分類ID來找商品 </param>
		/// <param name="productName"> 根據品名來找商品 </param>
		/// <param name="status"> 前台只會找到 狀態(status) 為true的商品，代表狀態是上架中 </param>
		/// <returns></returns>
		IEnumerable<ProductEntity> Search(int categoryId, string productName, bool? status);

		/// <summary>
		/// 傳回一筆商品
		/// </summary>
		/// <param name="productId"> 商品ID尋找 </param>
		/// <param name="status"> 只看到上架中的商品 </param>
		/// <returns></returns>
		ProductEntity Lord(int productId, bool? status);
	}
}
