using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Core;
using WA.BookStore.Site.Models.DTOs;
using WA.BookStore.Site.Models.ViewModels;

namespace WA.BookStore.Site.Models.UseCases
{
	public class EditCommand
	{
		public void Execute(EditProfileVM model)
		{
			UpdateProfileRequest request = model.ToRequest();

			MemberService service = new MemberService();
			service.UpdateProfile(request);
		}
	}
}