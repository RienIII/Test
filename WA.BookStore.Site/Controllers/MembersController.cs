using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WA.BookStore.Site.Models.Core;
using WA.BookStore.Site.Models.Core.Interface;
using WA.BookStore.Site.Models.DTOs;
using WA.BookStore.Site.Models.Entities;
using WA.BookStore.Site.Models.Infrastructures.Repositories;
using WA.BookStore.Site.Models.UseCases;
using WA.BookStore.Site.Models.ViewModels;

namespace WA.BookStore.Site.Controllers
{
    public class MembersController : Controller
    {
        private RegisterCommand command;
        IMemberRepository repo;
        public MembersController()
		{
            this.command = new RegisterCommand();
            this.repo = new MemberRepository();
		}

        /**************************** 會員中心 ****************************/

        [Authorize]
        public ActionResult Index()
		{
            return View();
		}

        /* 修改個人資訊 */
        [Authorize]
        public ActionResult EditProfile()
        {
            string currentEditProfilAccount = User.Identity.Name; // 取得 cookie 裡面的帳號
            MemberEntity entity = repo.Lord(currentEditProfilAccount);
            EditProfileVM model = entity.ToEditProfile();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditProfile(EditProfileVM model)
		{
            if(!ModelState.IsValid) return View(model);

            EditCommand command = new EditCommand();
            string currentUserAccount = User.Identity.Name;

            try
			{
                command.Execute(model, currentUserAccount);
			}
            catch (Exception ex)
			{
                ModelState.AddModelError(string.Empty, ex.Message);
			}

			if (!ModelState.IsValid)return View(model);
			
            return (string.Compare(User.Identity.Name, model.Account) == 0) 
                ? RedirectToAction("Login", "Members") 
                : RedirectToAction("Logout", "Members");
		}

        /* 重設密碼 */
        [Authorize]
        public ActionResult EditPassword()
		{
            return View();
		}

        [HttpPost]
        public ActionResult EditPassword(EditPasswordVM model)
        {
            if (!ModelState.IsValid) return View(model);

            string currentUserAccount = User.Identity.Name;
            EditCommand command = new EditCommand();

			try
			{
                command.UpdatePassword(model, currentUserAccount);
			}
            catch(Exception ex)
			{
                ModelState.AddModelError(string.Empty, ex.Message);
			}

            if(!ModelState.IsValid) return View(model);
            else return RedirectToAction("Index", "Members");
            
        }

        /* 忘記密碼 */
        public ActionResult ForgetPassword()
		{
            return View();
		}

        [HttpPost]
        public ActionResult ForgetPassword(ForgetPasswordVM model)
        {
            if (!ModelState.IsValid) return View(model);
            ForgetPasswordCommand command = new ForgetPasswordCommand();

            string urlTemplate = Request.Url.Scheme
                    + "://"
                    + Request.Url.Authority
                    + Url.Content("~/")
                    + "Members/ResetPassword?memberId={0}&confirmCode={1}";
            RegisterResponse response = command.ResetPassword(model, urlTemplate);

            if (response.IsSuccess)
            {
                return RedirectToAction("ConfirmResetPassword", "Members");
			}
            else
			{
                ModelState.AddModelError(string.Empty, response.ErrorMessage);
                return View(model);
            }
        }
        public ActionResult ResetPassword(int memberId, string confirmCode)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(int memberId, string confirmCode, ResetPasswordVM model)
        {
            MemberService service = new MemberService(repo);

            if(!ModelState.IsValid)return View(model);

			try
			{
                service.ResetPassword(memberId, confirmCode, model);
                return RedirectToAction("Login", "Members");
			}
            catch (Exception ex)
			{
                ModelState.AddModelError(String.Empty, ex.Message);
			}
            return View(model);
        }


        public ActionResult ConfirmResetPassword()
		{
            return View();
		}

        /**************************** 登入/登出 ****************************/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            
            var biz = new MemberService(repo);
            var result = biz.ValidationResult(model);

            if (!result.IsSuccess) ModelState.AddModelError(string.Empty, result.ErrorMessage);

            if (!ModelState.IsValid) return View(model);
            
            HttpCookie cookie;
            string resultUrl = command.ProcessLogin(model.Account, false, out cookie);
            Response.Cookies.Add(cookie);

            return Redirect(resultUrl);
        }

        [Authorize]
        public ActionResult Logout()
		{
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Members");
        }
        /**************************** 登入/登出 ****************************/

        /**************************** 註冊 ****************************/
        // GET: Members/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {
            if (!ModelState.IsValid)return View(model);

            string urlTemplate = Request.Url.Scheme
                    + "://"
                    + Request.Url.Authority
                    + Url.Content("~/")
                    + "Members/ResetPassword?memberId={0}&confirmCode={1}";
            RegisterResponse response = command.Execute(model, urlTemplate);

			if (response.IsSuccess)
			{
                return RedirectToAction("Index", "Home");
			}
			else
			{
                ModelState.AddModelError(response.FieldName, response.ErrorMessage);
                return View(model);
			}
        }
        public ActionResult ActiveRegister()
        {
            return View();
        }
        public ActionResult ConfirmRegister(int memberId, string confirmCode)
		{
            MemberService service = new MemberService(repo);
            service.ActiveRegister(memberId, confirmCode);

            return RedirectToAction("ActiveRegister", "Members");
		}
        /**************************** 註冊 ****************************/
    }
}