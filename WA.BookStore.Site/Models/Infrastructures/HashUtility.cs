using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WA.BookStore.Site.Models.Infrastructures
{
	public static class HashUtility // 如果class加static就不能繼承，而且裡面的method都要加static
									// 是否要加 static 就要看程式碼夠不夠簡單，簡單可用
	{
		// 密碼加密
		// 第一個參數是傳入 明碼，第二個是 加入鹽巴
		// 明碼代表沒有加密的密碼，鹽巴是在密碼中加入一些字串，因為使用者的密碼可能太簡單
		public static string ToSHA256(string plainText, string sale)
		{
			using (SHA256 mySHA256 =SHA256.Create())
			{
				var passwordBytes = Encoding.UTF8.GetBytes(plainText + sale);
				var hash = mySHA256.ComputeHash(passwordBytes);
				StringBuilder sb = new StringBuilder();
				foreach (var bytes in hash)
				{
					sb.Append(bytes.ToString("X2"));
				}
				return sb.ToString();
			}
		}
	}
}