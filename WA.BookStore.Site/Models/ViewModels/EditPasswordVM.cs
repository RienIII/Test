using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WA.BookStore.Site.Models.ViewModels
{
	public class EditPasswordVM
	{
		[Display(Name = "原始密碼")]
		[Required(ErrorMessage = "必填")]
		[DataType(DataType.Password)]
		[StringLength(50)]
		public string OriginalPassword { get; set; }

		[Display(Name = "新密碼")]
		[Required(ErrorMessage = "必填")]
		[DataType(DataType.Password)]
		[StringLength(50)]
		public string Password { get; set; }

		[Display(Name = "確認密碼")]
		[Required(ErrorMessage = "'新密碼'與'{0}'不符")]
		[DataType(DataType.Password)]
		[StringLength(50)]
		[Compare(nameof(Password))]
		public string ConfirmPassword { get; set; }
	}
}