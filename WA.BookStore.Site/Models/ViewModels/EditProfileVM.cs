using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WA.BookStore.Site.Models.ViewModels
{
	public class EditProfileVM
	{
        public int Id { get; set; }

        [Display(Name = "帳號")]
        [Required(ErrorMessage = "必填")]
        [StringLength(30)]
        public string Account { get; set; }

        [Display(Name = "暱稱")]
        [Required(ErrorMessage = "必填")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "必填")]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "手機號碼")]
        [StringLength(10)]
        public string Mobile { get; set; }
    }

    
}