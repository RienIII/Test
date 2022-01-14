using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WA.BookStore.Site.Models.ViewModels
{
	public class CheckoutVM
	{
		[Display(Name = "收件者")]
		[Required]
		[MaxLength(30)]
		public string Receiver { get; set; }

		[Required]
		[MaxLength(200)]
		[Display(Name = "地址")]
		public string Address { get; set; }

		[Required]
		[MaxLength(10)]
		[Display(Name = "手機號碼")]
		public string CellPhone { get; set; }
	}
}