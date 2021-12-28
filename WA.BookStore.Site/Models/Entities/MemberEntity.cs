using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Infrastructures;
using WA.BookStore.Site.Models.UseCases;
using WA.BookStore.Site.Models.ViewModels;
using Member = WA.BookStore.Site.Models.EFModels.Member;

namespace WA.BookStore.Site.Models.Entities
{
	public class MemberEntity
	{
		public const string SALT = "!@#$%^&";
		public int Id { get; set; }
		public string Account { get; set; }

        public string Password { get; set; }

        public string EnctrypatedPassword // 密碼加密
		{
			get
			{
				string salt = SALT;
				string result = HashUtility.ToSHA256(this.Password, salt);
				return result;
			}
		}

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public bool IsConfirmed { get; set; }

        public string ConfimCode { get; set; }
    }

    public static class MemberExt
	{
		public static MemberEntity ToMemberEntity(this Member member)
			=>new MemberEntity
			{
				Account = member.Account,
				Password = member.Password,
				Email = member.Email,
				Mobile = member.Mobile,
				Name = member.Name,
				IsConfirmed = member.IsConfirmed,
				ConfimCode = member.ConfimCode
			};
	}
	public static class MemberEntityExt
	{
		public static Member ToMember(this MemberEntity entity)
			=>new Member
			{
				Account = entity.Account,
				Password = entity.Password,
				Name = entity.Name,
				Email = entity.Email,
				Mobile = entity.Mobile,
				IsConfirmed = entity.IsConfirmed,
				ConfimCode = entity.ConfimCode
			};
		public static EditProfileVM ToEditProfile(this MemberEntity entity)
		{
			return new EditProfileVM
			{
				Id = entity.Id,
				Account = entity.Account,
				Email = entity.Email,
				Name = entity.Name,
				Mobile = entity.Mobile
			};
		}
	}
}