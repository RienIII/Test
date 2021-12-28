using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Entities;
using WA.BookStore.Site.Models.Infrastructures;

namespace WA.BookStore.Site.Models.ViewModels
{
	public class LoginVM
	{
		[Required(ErrorMessage = "必填*")]
		[Display(Name = "帳號")]
		public string Account { get; set; }

		[Required(ErrorMessage = "必填*")]
		[Display(Name = "密碼")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public string EnctrypatedPassword
		{
			get
			{
				string salt = MemberEntity.SALT;
				string result = HashUtility.ToSHA256(this.Password, salt);
				return result;
			}
		}
	}
}