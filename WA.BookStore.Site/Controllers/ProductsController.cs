using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WA.BookStore.Site.Models.Core;
using WA.BookStore.Site.Models.Core.Interfaces;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Exts;
using WA.BookStore.Site.Models.Infrastructures.Repositories;

namespace WA.BookStore.Site.Controllers
{
    public class ProductsController : Controller
    {
        private ProductService productService;
		public ProductsController()
		{
            var db = new AppDbContext();
            IProductRepository repo = new ProductRepository();
            productService = new ProductService(repo);
		}
        // GET: Products
        public ActionResult Index()
        {
            var data = productService
                .SearchAvtiveProduct(null, null)
                .Select(x => x.ToVM());

            return View(data);
        }
    }
}