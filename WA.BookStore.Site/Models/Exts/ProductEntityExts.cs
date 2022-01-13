using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Entities;
using WA.BookStore.Site.Models.ViewModels;

namespace WA.BookStore.Site.Models.Exts
{
	public static partial class ProductEntityExts
	{
		public static ProductVM ToVM(this ProductEntity product)
		{
			return new ProductVM
			{
				Id = product.Id,
				Name = product.Name,
				CategoryName = product.Category.Name,
				Description = product.Description,
				Price = product.Price,
				Stock = product.Stock,
				ProductImage = product.ProductImage
			};
		}
	}
}