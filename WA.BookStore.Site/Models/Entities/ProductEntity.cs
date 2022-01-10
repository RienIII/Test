using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BookStore.Site.Models.Entities
{
	public class ProductEntity
	{
        public int Id { get; set; }

        // 要用自己的不要用集合，複製過來記得改
        public CategoryEntity Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public bool Status { get; set; }

        public string ProductImage { get; set; }

        public int Stock { get; set; }
    }
}