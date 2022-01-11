using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Infrastructures;
using WA.BookStore.Site.Models.ValueObjects;

namespace WA.BookStore.Site.Models.Entities
{
	public class OrderEntity
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public string CustomerAccount { get; set; }

		private List<OrderItemEntity> _Items;
		public List<OrderItemEntity> Items
		{
			get => _Items;
			set => _Items = value == null || value.Count == 0 ? throw new Exception("不能是空的") : value;
		}

		public int Total
		{
			get => Items.Sum(x=>x.SubTotal);
		}

		/// <summary>
		/// 是否退貨
		/// </summary>
		public bool RequestRefund { get; set; }

		/// <summary>
		/// 退貨日期
		/// </summary>
		public DateTime? RequestRefunTime { get; set; }

		/// <summary>
		/// 訂單建立時間
		/// </summary>
		public DateTime CreateTime { get; set; }

		private int _Status;
		/// <summary>
		/// 1 = 成立訂單；2 = 已經結案；3 = 退訂
		/// </summary>
		public int Status
		{
			get => _Status;
			set => _Status = value <= 3 && value >=1 ? value : throw new Exception("只能在1~3之間");
		}

		private ShippingInfo _shippingInfo;
		/// <summary>
		/// 收貨人資訊
		/// </summary>
		public ShippingInfo shippingInfo
		{
			get => _shippingInfo;
			set => _shippingInfo = Validator.Required(value);
		}

		/// <summary>
		/// 是否可以退貨
		/// </summary>
		public bool AllowRefund
		{
			get
			{
				// 有這筆訂單，還沒結案
				if (_Status == 1) return true;

				// 已經結案，但是在 7 天可退貨期間內
				if(_Status == 2 && In7Day) return true;
				
				return false;
			}
		}
		private bool In7Day
		{
			get
			{
				return (DateTime.Today - CreateTime).TotalDays <= 7.0;
			}
		}
	}
}