using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Entities;
using WA.BookStore.Site.Models.ViewModels;

namespace WA.BookStore.Site.Models.DTOs
{
	public class UpdateProfileRequest
	{
		// 從 cookie 取出當前使用者的帳號
		public string CurrentUserAccount { get; set; }

		// 有修改或是沒有修改的帳號
		public string Account { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public string Mobile { get; set; }
	}

	public static class EditProfileVMExts
	{
		public static UpdateProfileRequest ToRequest(this EditProfileVM model, string currentUserAccount)
		{
			return new UpdateProfileRequest
			{
				CurrentUserAccount = currentUserAccount,
				Account = model.Account,
				Name = model.Name,
				Email = model.Email,
				Mobile = model.Mobile
			};
		}
	}
	public static class UpdateProfileRequestExt
	{
		public static MemberEntity ToEntity(this UpdateProfileRequest request, MemberEntity entity)
		{
			MemberEntity result = new MemberEntity();
			result.Id = entity.Id;
			result.IsConfirmed = entity.IsConfirmed;
			result.ConfimCode = entity.ConfimCode;
			result.Password = entity.Password;

			result.Account = request.Account;
			result.Name = request.Name;
			result.Email = request.Email;
			result.Mobile = request.Mobile;
			return result;
		}
	}
	
}