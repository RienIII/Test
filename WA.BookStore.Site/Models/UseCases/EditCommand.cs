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
		MemberService service = new MemberService();
		public void Execute(EditProfileVM model, string currentUserAccount)
		{
			
			UpdateProfileRequest request = model.ToRequest(currentUserAccount);

			service.UpdateProfile(request);
		}

		public void UpdatePassword(EditPasswordVM model, string currentUserAccount)
		{
			UpdatePasswordRequest request = model.ToRequest(currentUserAccount);
			service.UpdatePassword(request);
		}
	}
}