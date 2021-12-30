using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.UseCases
{
	public class RegisterResponse // 如果新增成功或是失敗，會回傳訊息
	{
		public bool IsSuccess { get; set; } // 成功與否
		public string ErrorMessage { get; set; } // 失敗的話 回傳錯誤訊息
		public string FieldName { get; set; } // 錯誤的欄位
		public RegisterEntity Data { get; set; } // 成功會使用的資料，像是要寄信寄給誰 標題是甚麼

		public static RegisterResponse Fail()
		{
			return new RegisterResponse
			{
				IsSuccess = false,
				ErrorMessage = "'帳號'或是'Email'有誤"
			};
		}
	}
}