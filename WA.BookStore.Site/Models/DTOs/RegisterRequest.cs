using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.UseCases
{
	public class RegisterRequest // 會到 DomainService(Core) 
	{
        public string Account { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; } 
    }
    public static class MemberExtensions
    {
        public static MemberEntity ToMemberEntity(this RegisterRequest request, string confimCode)
            => new MemberEntity
            {
                Account = request.Account,
                Password = request.Password,
                Name = request.Name,
                Email = request.Email,
                Mobile = request.Mobile,
                IsConfirmed = false,
                ConfimCode = confimCode
            };
    }
}