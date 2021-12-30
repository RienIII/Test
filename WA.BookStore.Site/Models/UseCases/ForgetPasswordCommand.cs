using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helper;
using WA.BookStore.Site.Models.Core;
using WA.BookStore.Site.Models.ViewModels;

namespace WA.BookStore.Site.Models.UseCases
{
	public class ForgetPasswordCommand
	{
		public RegisterResponse ResetPassword(ForgetPasswordVM model, string urlTemplate)
		{
			MemberService service = new MemberService();

			RegisterResponse response = service.RequestResetPassword(model.Account, model.Email);

			if (response.IsSuccess)
			{
				string url = string.Format(urlTemplate, response.Data.Id, response.Data.ConfirmCode);
				new EmailHelper().SendForgetPasswordEmail(url, response.Data.Name, response.Data.Email);
			}

			return response;
		}
	}
}