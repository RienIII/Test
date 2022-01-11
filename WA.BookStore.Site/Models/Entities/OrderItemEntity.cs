using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Infrastructures;

namespace WA.BookStore.Site.Models.Entities
{
	public class OrderItemEntity
	{
		public OrderItemEntity(int id, OrderProductEntity product, int qty)
		{
			this.Id = id;
			this.Product = product;
			this.Qty = qty;
		}

		public int Id { get; set; }

		private OrderProductEntity _Product;
		public OrderProductEntity Product
		{
			get => _Product;
			set => _Product = value != null ? value : throw new Exception("商品不能是null");
		}

		private int _Qty;
		public int Qty
		{
			get => _Qty;
			set => _Qty = Validator.GreaterThanZero(value);
		}
		public int SubTotal
		{
			get => Product.Price * Qty;
		}
	}
}