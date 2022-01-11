using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Infrastructures;

namespace WA.BookStore.Site.Models.Entities
{
	public class OrderProductEntity
	{
		public OrderProductEntity(int id, string productName, int price)
		{
			this.Id = id;
			this.ProductName = productName;
			this.Price = price;
		}
		public int Id { get; set; }

		private string _ProductName { get; set; }
		public string ProductName
		{
			get => _ProductName;
			set
			{
				new DataValidator<string>(value, "商品名稱").RequiredString();
				_ProductName = value;
			}
		}

		private int _Price;
		public int Price
		{
			get => _Price;
			set
			{
				new DataValidator<int>(value, "商品價格").GreaterOrEqualThanZero(0);
				_Price = value;
			}
		}
	}
}