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
	public class CustomerRepository : ICustomerRepository
	{
		private readonly AppDbContext db;
		public CustomerRepository()
		{
			this.db = new AppDbContext();
		}
		public CustomerRepository(AppDbContext dataBase)
		{
			this.db = dataBase;
		}
		public int GetCustormerId(string account)
			=>db.Members.SingleOrDefault(x=>x.Account == account && x.IsConfirmed == true).Id;

		public bool IsExist(string account)
			=>db.Members.SingleOrDefault(x=>x.Account == account && x.IsConfirmed == true) != null;

		public CustomerEntity Lord(string account)
			=>db.Members.SingleOrDefault(x=>x.Account == account && x.IsConfirmed == true).ToCustomerEntity();
	}
}