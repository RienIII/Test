using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Entities;
using WA.BookStore.Site.Models.ViewModels;

namespace WA.BookStore.Site.Models.DTOs
{
	public class UpdatePasswordRequest
	{
		public string UserAccount { get; set; }
		public string OriginalPassword { get; set; }
		public string Password { get; set; }
	}

	public static class EditPasswordVMExts
	{
		public static UpdatePasswordRequest ToRequest(this EditPasswordVM model, string currentUserAccount)
		{
			return new UpdatePasswordRequest
			{
				UserAccount = currentUserAccount,
				OriginalPassword = model.OriginalPassword,
				Password = model.Password
			};
		}
	}
}