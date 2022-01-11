using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA.BookStore.Site.Models.Core.Interfaces
{
	public interface IStockRepository
	{
		/// <summary>
		/// 異動庫存都是呼叫 Update 在StockService就會決定 "正數" 還是 "負數" 
		/// </summary>
		/// <param name="info"> 
		/// 這裡的陣列，照理來說應該寫一個class來用
		/// 懶得寫可以用這樣的方式 叫做 value tuple，之前沒有變數名稱，新版的才有
		/// </param>
		void Update((int productId, int qty)[] info);
	}
}
