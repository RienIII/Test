using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WA.BookStore.Site.Models.ViewModels
{
	public class ProductVM
	{
        public int Id { get; set; }

        [Display(Name = "名稱")]
        public string Name { get; set; }

        [Display(Name = "分類")]
        public string CategoryName { get; set; }

        [Display(Name = "商品描述")]
        public string Description { get; set; }

        [Display(Name = "售價")]
        public int Price { get; set; }

        public string ProductImage { get; set; }

        [Display(Name = "庫存量")]
        public int Stock { get; set; }
    }
}