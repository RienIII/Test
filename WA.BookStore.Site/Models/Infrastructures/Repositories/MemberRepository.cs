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

		public bool IsExist(string account, int Id)
		{
			// 要排除自己的ID，在尋找其他資料中有沒有跟你需要修改的帳號相同
			var entity = db.Members.SingleOrDefault(x =>x.Id != Id && x.Account == account);

			return (entity == null) ? false : true;
			// return entity != null; 其實這樣寫就可以了
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

		// 不能修改密碼
		public void Update(MemberEntity entity)
		{
			var member = db.Members.Find(entity.Id);

			member.Account = entity.Account;
			member.Name = entity.Name;
			member.Mobile = entity.Mobile;
			member.Email = entity.Email;

			db.SaveChanges();
		}

		// 修改密碼
		public void UpdatePassword(MemberEntity entity)
		{
			var member = db.Members.Find(entity.Id);

			member.Password = entity.EnctrypatedPassword;

			db.SaveChanges();
		}
	}
}