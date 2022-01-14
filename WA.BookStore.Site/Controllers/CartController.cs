using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WA.BookStore.Site.Models.Core;
using WA.BookStore.Site.Models.Core.Interfaces;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Infrastructures.Repositories;
using WA.BookStore.Site.Models.ValueObjects;
using WA.BookStore.Site.Models.ViewModels;

namespace WA.BookStore.Site.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        ICartService cartService;
        IOrderService orderService;
        IStockService stockService;
		public CartController()
		{
            AppDbContext db = new AppDbContext();

            ICartRepository cartRepo = new CartRepository(db);
            IProductRepository productRepo = new ProductRepository(db);
            ICustomerRepository customerRepo = new CustomerRepository(db);
            IOrderRepository orderRepo = new OrderRepository(db);
            IStockRepository stockRepo = new StockRepository(db);

            cartService = new CartService(cartRepo, productRepo, customerRepo);
            orderService = new OrderService(orderRepo);
            this.stockService = new StockService(stockRepo);
		}

        private string CustomerAccount => User.Identity.Name;

        // GET: Cart/AddItem
        public ActionResult AddItem(int productId)
        {
            cartService.AddItem(CustomerAccount, productId);

            // 因為加入購物車沒有甚麼東做，所以傳回空的
            return new EmptyResult();
        }

        public ActionResult Info()
		{
            var cart = cartService.Current(CustomerAccount);

            return View(cart);
		}

        public ActionResult UpdateItem(int productId, int qty)
		{
            qty = qty <= 0 ? 0 : qty;

            cartService.UpdateItem(CustomerAccount, productId, qty);

            return new EmptyResult();
		}

        public ActionResult Checkout()
		{
            var cart = cartService.Current(CustomerAccount);

			if (!cart.AllowCheckout)
			{
                ViewBag.ErrorMessage = "購物車是空的，無法進行結帳";
			}
            return View();
		}

        [HttpPost]
        public ActionResult Checkout(CheckoutVM model, ShippingInfo info)
		{
            if(!ModelState.IsValid)return View(model);

            var cart = cartService.Current(CustomerAccount);
			if (!cart.AllowCheckout)
			{
                ModelState.AddModelError(string.Empty, "購物車是空的，無法進行結帳");
                return View(model);
			}

            var mediator = new CartMediator(cartService, orderService, stockService);

            cartService.Checkout(CustomerAccount, info);

            return View("CheckoutConfirm");
		}
    }
}