using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Infrastructures;

namespace WA.BookStore.Site.Models.Entities
{
	public class CartProductEntity
	{
		public int Id { get; set; }

		private string _Name;
		public string Name
		{
			get => _Name;
			set => _Name = Validator.Required(value);
		}

		private int _Price;
		public int Price
		{
			get => _Price;
			set => _Price = Validator.GreaterOrEqualThanZero(value);
		}
	}
}