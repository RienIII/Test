using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.Core.Interface;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Entities;

namespace WA.BookStore.Site.Models.Infrastructures.Repositories
{
	
	public class MemberRepository : IMemberRepository
	{
		private AppDbContext db;
		public MemberRepository()
		{
			this.db = new AppDbContext();
		}

		public void ActiveRegister(int memberId)
		{
			var member = db.Members.Find(memberId);
			member.IsConfirmed = true;
			member.ConfimCode = null;
			db.SaveChanges();
		}

		public void Create(MemberEntity entity)
		{
			Member member = entity.ToMember();

			db.Members.Add(member);
			db.SaveChanges();
		}

		public bool IsExist(string account)
		{
			var entity = db.Members.SingleOrDefault(x => x.Account == account);

			return (entity == null) ? false : true;
		}

		public MemberEntity Lord(int memberId)
		{
			return db.Members.SingleOrDefault(x => x.Id == memberId).ToMemberEntity();
			
			// member = db.Members.Find(memberId);

			// 也可以狠一點
			// db.Members.SingleOrDefault(x=>x.Id == memberId && x.ConfimCode != null);

			//return new MemberEntity
			//{
			//	Id = member.Id,
			//	Account = member.Account,
			//	Email = member.Email,
			//	Password = member.Password,
			//	Name = member.Name,
			//	Mobile = member.Mobile,
			//	IsConfirmed = member.IsConfirmed,
			//	ConfimCode = member.ConfimCode,
			//};
			//return entity;
		}
		public MemberEntity Lord(string account)
			=>db.Members
			.SingleOrDefault(x=>x.Account == account)
			.ToMemberEntity();
	}
}