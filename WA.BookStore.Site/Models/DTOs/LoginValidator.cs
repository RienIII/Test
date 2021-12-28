using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BookStore.Site.Models.DTOs
{
	public class LoginValidator
	{
		public bool IsSuccess { get; set; }
		public string ErrorMessage { get; set; }
		public static LoginValidator Success() 
			=> new LoginValidator { IsSuccess = true };
		public static LoginValidator Failure(string errorMessage) 
			=> new LoginValidator { IsSuccess = false, ErrorMessage = errorMessage };
	}
}