using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.Exts
{
	public static class CategoryExts
	{
		public static CategoryEntity ToEntity(this Category category)
		{
			return new CategoryEntity
			{
				Id = category.Id,
				Name = category.Name,
				DisplayOrder = category.DisplayOrder
			};
		}
	}
}