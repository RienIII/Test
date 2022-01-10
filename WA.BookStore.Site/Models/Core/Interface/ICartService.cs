using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BookStore.Site.Models.DTOs;
using WA.BookStore.Site.Models.Entities;
using WA.BookStore.Site.Models.ValueObjects;

namespace WA.BookStore.Site.Models.Core.Interface
{
	public interface ICartService
	{
		/// <summary>
		/// 客戶發出結帳請求，會觸發事件
		/// </summary>
		event Action<ICartService, string> RequestCheckout;

		/// <summary>
		/// 每一個會員同一時間只會有一個購物車，結帳時清空購物車；若沒有購物車則建立一個
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		CartEntity Current(string account);

		/// <summary>
		/// 新增訂單項目
		/// </summary>
		/// <param name="account"></param>
		/// <param name="productId"> 要新增的商品ID </param>
		/// <param name="qty"> 新增數量 預設為:1 </param>
		void AddItem(string account, int productId, int qty = 1);

		/// <summary>
		/// 修改購物車裡面的商品數量
		/// </summary>
		/// <param name="account"></param>
		/// <param name="productId">要修改的商品ID</param>
		/// <param name="newQty">更改的數量</param>
		void UpdateItem(string account, int productId, int newQty);

		/// <summary>
		/// 移除一個在購物車的商品項目
		/// </summary>
		/// <param name="account"></param>
		/// <param name="productId">需要移除的商品ID</param>
		void RemoveItem(string account, int productId);

		/// <summary>
		/// 清空購物車
		/// </summary>
		/// <param name="account"></param>
		void EmptyCart(string account);

		/// <summary>
		/// 發出結帳請求會呼叫這個程式，這個程式會觸發事件
		/// </summary>
		/// <param name="account"></param>
		/// <param name="shippingInfo"></param>
		void Checkout(string account, ShippingInfo shippingInfo);

		/// <summary>
		/// 當結帳時，會傳一筆資料給訂單(OrderService)，資料的轉換
		/// </summary>
		/// <param name="cart">傳入一個購物車，輸出成訂單格式的資料</param>
		/// <returns></returns>
		CreateOrderRequest ToCreateOrderRequest(CartEntity cart);

		/// <summary>
		/// 這個也是資料轉換，要給庫存(StockService)用的
		/// </summary>
		/// <param name="cart">傳入一個購物車，輸出時只要一些資料而已</param>
		/// <returns></returns>
		DeductStockInfo[] GetDeductStockInfo(CartEntity cart);
	}
}