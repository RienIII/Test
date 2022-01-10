using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Core.Interface;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.Core
{
	public class CustomerService
	{
		private readonly ICustomerRepository repository;
		public CustomerService(ICustomerRepository repo)
		{
			this.repository = repo;
		}

		public CustomerEntity Lord(string account)
		{
			return repository.IsExist(account)
				? repository.Lord(account)
				: throw new Exception("找不到有權限的會員");
		}
		public int GetCustomerId(string account)
		{
			return repository.Lord(account).Id;
		}
	}
}