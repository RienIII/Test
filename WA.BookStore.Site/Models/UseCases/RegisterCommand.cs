using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WA.BookStore.Site.Models.Core;
using WA.BookStore.Site.Models.ViewModels;

namespace WA.BookStore.Site.Models.UseCases
{
	public class RegisterCommand
	{
		public RegisterResponse Execute(RegisterVM model)
		{
			var service = new MemberService();

			RegisterRequest request = model.ToRequest();

			RegisterResponse response = service.CreateNewMember(request);

			if (response.IsSuccess)
			{
				// todo
			}

			return response;
		}

		public string ProcessLogin(string account, bool rememberMe, out HttpCookie cookie)
		{
			string role = String.Empty;
			FormsAuthenticationTicket ticket =
				new FormsAuthenticationTicket(
					1,
					account,
					DateTime.Now,
					DateTime.Now.AddDays(1),
					rememberMe,
					role,
					"/");

			string value = FormsAuthentication.Encrypt(ticket);

			cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value);

			string url = FormsAuthentication.GetRedirectUrl(account, true);

			return url;
		}
	}
}