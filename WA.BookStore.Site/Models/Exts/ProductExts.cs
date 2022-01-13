using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Entities;
using WA.BookStore.Site.Models.ViewModels;

namespace WA.BookStore.Site.Models.Exts
{
	public static class ProductExts
	{
		public static ProductEntity ToEntity(this Product product)
		{
			return new ProductEntity
			{
				Id = product.Id,
				Name = product.Name,
				Category = product.Category.ToEntity(),
				Description = product.Description,
				Price = product.Price,
				ProductImage = product.ProductImage,
				Status = product.Status,
				Stock = product.Stock
			};
		}
		public static CartProductEntity ToCartProductEntity(this Product product)
		{
			return new CartProductEntity
			{
				Id = product.Id,
				Name = product.Name,
				Price = product.Price
			};
		}
		public static OrderProductEntity ToOrderProductEntity(this Product product)
		{
			return new OrderProductEntity
			(
				product.Id,
				product.Name,
				product.Price
			);
		}
	}
}