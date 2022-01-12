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
		/// <summary>
		/// 訂單項目商品
		/// </summary>
		public OrderProductEntity Product
		{
			get => _Product;
			set => _Product = value != null ? value : throw new Exception("商品不能是null");
		}

		private int _Qty;
		/// <summary>
		/// 商品數量
		/// </summary>
		public int Qty
		{
			get => _Qty;
			set
			{
				new DataValidator<int>(value, "數量").GreaterThan(0);
				_Qty = value;
			}
		}
		/// <summary>
		/// 該商品小計
		/// </summary>
		public int SubTotal
		{
			get => Product.Price * Qty;
		}
	}
}