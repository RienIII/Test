using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WA.BookStore.Site.Models.ViewModels;

namespace WA.BookStore.Site.Controllers
{
	public class HomeController : Controller
	{
		private string Path {
			get
			{
				// 在Web.config裡面的appSettings add key=""，把一些設定寫好，這樣就不用每一次都寫
				string folder = ConfigurationManager.AppSettings["productImageFolder"]; 
				return Server.MapPath(folder);
			}
		}
		public ActionResult Index()
		{
			ViewBag.Path = Path;
			return View();
		}

		[Authorize]
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		[Authorize]
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}