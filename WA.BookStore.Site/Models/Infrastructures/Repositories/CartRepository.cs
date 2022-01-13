using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WA.BookStore.Site.Models.Core.Interfaces;
using WA.BookStore.Site.Models.EFModels;
using WA.BookStore.Site.Models.Entities;
using WA.BookStore.Site.Models.Exts;

namespace WA.BookStore.Site.Models.Infrastructures.Repositories
{
	public class CartRepository : ICartRepository
	{
		private readonly AppDbContext db;
		public CartRepository(AppDbContext dataBase)
		{
			this.db = dataBase;
		}
		public bool IsExist(string account)
		{
			return db.Carts.SingleOrDefault(x=>x.MemberAccount == account) != null;
		}
		public CartEntity CreateNewCart(string account)
		{
			var cart = new Cart { MemberAccount = account };
			db.Carts.Add(cart);
			db.SaveChanges();

			return Lord(account);
		}
		public CartEntity Lord(string account)
		{
			// 尋找資料，因為會先找到 Cart 再到 CartItems，所以要加 Include
			// 如果還要再找裡面的東西 就要在 CartItems 下面再加 Select 找到 Product
			// 如果用 MVC Core Include((x=>x.CartItems).ThenInclude(x2=>x2.Product) 這樣寫就好
			return db.Carts
				.AsNoTracking()
				.Include(x=>x.CartItems.Select(x2=>x2.Product))
				.SingleOrDefault(x=>x.MemberAccount == account)
				.ToEntity();
		}
		public void EmptyCart(string account)
		{
			var cart = db.Carts.SingleOrDefault(x=>x.MemberAccount == account);
			if (cart == null) return;
			db.Carts.Remove(cart);
			db.SaveChanges();
		}

		// 這邊的步驟是先找出資料庫裡面該使用者的購物車=>
		public void Save(CartEntity entity)
		{
			Cart cart = entity.ToEF();

			Cart efInDb = db.Carts
				.Include(x=>x.CartItems)
				.Single(x=>x.Id == entity.Id);

			List<CartItem> efItemInDB = efInDb.CartItems.ToList();

			// 若 efInDb 中的商品不存在於 cartEF 中，表示使用者刪除了
			var delectProducts = efItemInDB.Select(x=>x.ProductId).Except(cart.CartItems.Select(x2=>x2.ProductId)).ToList();

			foreach(var productId in delectProducts)
			{
				var delectItem = efInDb.CartItems.Single(x=>x.ProductId == productId);

				// 不能直接remove item, 需要標註它已被刪除，才能正常執行
				db.Entry(delectItem).State = EntityState.Modified;
			}

			foreach (var item in cart.CartItems)
			{
				if(item.Id == 0)
				{
					efInDb.CartItems.Add(item);
				}
				else
				{
					efInDb.CartItems.SingleOrDefault(x=>x.Id == item.Id).Qty = item.Qty;
				}
			}

			db.SaveChanges();
		}
	}
}