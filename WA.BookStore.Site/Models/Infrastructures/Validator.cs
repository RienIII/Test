using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BookStore.Site.Models.Infrastructures
{
	public class Validator
	{
		/// <summary>
		/// 必填
		/// </summary>
		/// <param name="value">某個字串必填</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static string Required(string value)
		{
			return (!string.IsNullOrEmpty(value)) 
				? value 
				: throw new ArgumentNullException(nameof(value));
		}
		/// <summary>
		/// 數值大於0
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static int GreaterThanZero(int value)
		{
			return value > 0 
				? value 
				: throw new ArgumentOutOfRangeException(nameof(value));
		}

		/// <summary>
		/// 數值大於或等於0
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static int GreaterOrEqualThanZero(int value)
		{
			return value >= 0
				? value
				: throw new ArgumentOutOfRangeException(nameof(value));
		}
	}
}