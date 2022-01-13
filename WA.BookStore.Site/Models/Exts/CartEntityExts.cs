using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.DTOs;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.Exts
{
	public static partial class CartEntityExts
	{
		public static Cart ToEF(this CartEntity entity)
		{
			var items = entity.GetItem().Select(x => x.ToEF(entity.Id)).ToList();

			return new Cart { Id = entity.Id, MemberAccount = entity.Account, CartItems = items };
		}
	}
}