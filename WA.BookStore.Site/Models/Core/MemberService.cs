using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WA.BookStore.Site.Models.Core.Interface;
using WA.BookStore.Site.Models.DTOs;
using WA.BookStore.Site.Models.Entities;
using WA.BookStore.Site.Models.Infrastructures;
using WA.BookStore.Site.Models.Infrastructures.Repositories;
using WA.BookStore.Site.Models.UseCases;
using WA.BookStore.Site.Models.ViewModels;

namespace WA.BookStore.Site.Models.Core
{
	public class MemberService
	{
		private readonly IMemberRepository _repo;
		public MemberService()
		{
			this._repo = new MemberRepository();
		}
		public MemberService(IMemberRepository repo)
		{
			this._repo = repo;
		}

		/**************************** 註冊 ****************************/
		public RegisterResponse CreateNewMember(RegisterRequest request)
		{
			// 判斷欄位是否正確

			// 判斷帳號是否存在
			if (_repo.IsExist(request.Account))
			{
				return new RegisterResponse { 
					IsSuccess = false, 
					FieldName = "Account", 
					ErrorMessage = "帳號已存在" };
			}

			// 真正建立一個會員紀錄
			//	 建立 ConfirmCode
			//	 叫用 IMemberRepository 進行建檔工作
			string confirmCode = Guid.NewGuid().ToString("N"); // 產生字串 8-4-4-4-12 ，裡面的"-"如果要去掉要加 "N"

			MemberEntity entity = new MemberEntity();
			entity = request.ToMemberEntity(confirmCode);
			
			_repo.Create(entity);

			return new RegisterResponse
			{
				IsSuccess = true,
				Data = new RegisterEntity
				{
					Name = request.Account,
					Email = request.Email,
					ConfirmCode = confirmCode
				}
			};
		}

		/**************************** 啟動會員資格 ****************************/
		public void ActiveRegister(int memberId, string confirmCode)
		{
			MemberEntity entity = _repo.Lord(memberId);
			if (entity == null) return;

			// if (entity.ConfimCode != confirmCode) return;
			// 可以寫成下面的 要比較的兩個值如果相等 會是0
			// 第一個值較大為正數1~...，第二個大為負數 -1~...，只要是正或是負數就好像是輸入99 or -100
			if (string.Compare(entity.ConfimCode, confirmCode) != 0) return;

			_repo.ActiveRegister(memberId);
		}

		/**************************** 登入 ****************************/
		public LoginValidator ValidationResult(LoginVM model)
		{
			MemberEntity entity = _repo.Lord(model.Account);

			if(entity == null) return LoginValidator.Failure("帳密有誤");
			if (!entity.IsConfirmed) return LoginValidator.Failure("會員資格尚未啟用");

			return (string.Compare(entity.Password, model.EnctrypatedPassword) == 0)
				? LoginValidator.Success()
				: LoginValidator.Failure("帳密錯誤");
		}

		/**************************** 修改資料 ****************************/
		public void UpdateProfile(UpdateProfileRequest request)
		{
			// 取得原始資料
			MemberEntity entity = _repo.Lord(request.CurrentUserAccount);
			if (entity == null) throw new Exception("找不到需要修改的會員資料");
			
			// 判斷需要更新的帳號是否被使用過
			// 第二個參數 是要看，除了自己ID以外，有沒有人跟你所要修改的帳號相同
			if(_repo.IsExist(request.Account, entity.Id))throw new Exception("帳號已被使用");
			entity = request.ToEntity(entity);
			_repo.Update(entity);
		}
		public void UpdatePassword(UpdatePasswordRequest request)
		{
			MemberEntity entity = _repo.Lord(request.UserAccount);
			if (entity == null) throw new Exception("找不到需要修改的會員資料");

			string enctryptedPassword = HashUtility.ToSHA256(request.OriginalPassword, MemberEntity.SALT);
			if (!(string.Compare(entity.Password, enctryptedPassword) == 0)) throw new Exception("與原始密碼不相符");

			entity.Password = request.Password;

			_repo.UpdatePassword(entity);
		}
	}
}