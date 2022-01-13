using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.Exts
{
	public static partial class MemberExts
	{
		public static CustomerEntity ToCustomerEntity(this Member member)
		{
			return new CustomerEntity
			{
				Id = member.Id,
				Account = member.Account
			};
		}
	}
}