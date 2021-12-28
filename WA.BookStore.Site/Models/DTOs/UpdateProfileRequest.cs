using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.ViewModels;

namespace WA.BookStore.Site.Models.DTOs
{
	public class UpdateProfileRequest
	{
		public int Id { get; set; }

		public string Account { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public string Mobile { get; set; }
	}

	public static class EditProfileExts
	{
		public static UpdateProfileRequest ToRequest(this EditProfileVM model)
		{
			return new UpdateProfileRequest
			{
				Id = model.Id,
				Account = model.Account,
				Name = model.Name,
				Email = model.Email,
				Mobile = model.Mobile
			};
		}
	}
}