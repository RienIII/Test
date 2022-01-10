using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.DTOs;
using WA.BookStore.Site.Models.UseCases;

namespace WA.BookStore.Site.Models.ViewModels
{
	public class RegisterVM
	{
		public int Id { get; set; }

		[Display(Name = "帳號")]
        [Required(ErrorMessage = "必填*")]
        [StringLength(30)]
        public string Account { get; set; }

        [Display(Name = "密碼")]
        [Required(ErrorMessage = "必填*")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "確認密碼")]
        [Required]
        [StringLength(50)]
        [Compare(nameof(Password))] // 跟上面的 Password 比較是不是相同
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } // 確認密碼

        [Display(Name = "暱稱")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "手機號碼")]
        [StringLength(10)]
        public string Mobile { get; set; } // 手機號碼

    }
    public static class RegisterRequestExt
	{
        public static RegisterRequest ToRequest(this RegisterVM source)
		{
            return new RegisterRequest
            {
                Account = source.Account,
                Password = source.Password,
                Name = source.Name,
                Email = source.Email,
                Mobile = source.Mobile,
            };
		}
	}
}