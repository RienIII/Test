using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.ValueObjects;

namespace WA.BookStore.Site.Models.Infrastructures
{
	public class Validator
	{
		/// <summary>
		/// 必填，不能是null或是Empty
		/// </summary>
		/// <param name="value">某個字串必填</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static string Required(string value)
			=>(!string.IsNullOrEmpty(value)) ? value : throw new ArgumentNullException(nameof(value));

		/// <summary>
		/// 必須要有收貨人資訊
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static ShippingInfo Required(ShippingInfo value)
			=>value != null ? value : throw new ArgumentNullException(nameof(value));

		/// <summary>
		/// 數值大於0
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static int GreaterThanZero(int value)
			=>value > 0 ? value : throw new ArgumentOutOfRangeException(nameof(value));

		/// <summary>
		/// 數值大於或等於0
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static int GreaterOrEqualThanZero(int value)
			=>value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(value));


	}

	/// <summary>
	/// 驗證器
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class DataValidator<T>
	{
		public T Data { get; set; }
		public string DisplayName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data">需要驗證的資料</param>
		/// <param name="displayName">資料名稱是甚麼</param>
		public DataValidator(T data, string displayName)
		{
			Data = data;
			DisplayName = displayName;
		}

		public DataValidator<T> Required()
		{
			if (Data == null) throw new Exception($"{DisplayName}必填");

			return this;
		}

		/// <summary>
		/// 文字不能是NULL或是Empty
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public DataValidator<T> RequiredString()
		{
			if (typeof(T) == typeof(string))
			{
				var value = Convert.ToString(Data);
				if(string.IsNullOrEmpty(value)) throw new Exception($"{DisplayName}必填");
			}

			return this;
		}

		/// <summary>
		/// 數值必須大於minValue
		/// </summary>
		/// <param name="minValue">指定大於的數值</param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public DataValidator<T> GreaterThan(int minValue)
		{
			if(typeof(T) == typeof(int))
			{
				int value = Convert.ToInt32(Data);
				if (value < minValue) throw new Exception($"{DisplayName}值要大於0");
			}

			return this;
		}

		/// <summary>
		/// 數值必須大於等於minValue
		/// </summary>
		/// <param name="minValue">指定大於等於的數值</param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public DataValidator<T> GreaterOrEqualThan(int minValue)
		{
			if (typeof(T) == typeof(int))
			{
				int value = Convert.ToInt32(Data);
				if (value < minValue) throw new Exception($"{DisplayName}值要大於等於0");
			}

			return this;
		}
	}

}