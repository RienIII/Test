using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Entities;
using WA.BookStore.Site.Models.UseCases;

namespace WA.BookStore.Site.Models.Core.Interface
{
	public interface IMemberRepository
	{
		bool IsExist(string account);
		bool IsExist(string account, int Id);
		void Create(MemberEntity entity);
		MemberEntity Lord(int memberId);
		MemberEntity Lord(string account);
		void ActiveRegister(int memberId);
		void Update(MemberEntityNoPassword entity);
		void Update(int memberId, string enctryptedPassword);
		void UpdatePassword(int memberId, string enctryptedPassword);
	}
}