using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BookStore.Site.Models.Entities
{
	public class CartProductEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
	}
}