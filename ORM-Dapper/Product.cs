using System;
namespace ORM_Dapper
{
	public class Product
	{
		public int productId { get; set; }
		public string name { get; set; }
		public int price { get; set; }
		public int categoryID { get; set; }
		public bool onSale { get; set; }
		public string stockLevel { get; set; }
		
	}
}

