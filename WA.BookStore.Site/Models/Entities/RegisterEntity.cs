using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BookStore.Site.Models.Entities
{
	public class RegisterEntity // 從 Core(DomainService) 新增資料成功，會順便放一些基本資料
	{
		public int Id { get; set; }
		public string Account { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string ConfirmCode { get; set; }
	}
}