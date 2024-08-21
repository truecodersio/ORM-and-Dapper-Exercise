using System;
namespace ORM_Dapper
{
	public class Product
	{
		//here add each columns from the products table inside the best buy db as properties

		  public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; }
        public string StockLevel { get; set; }
	}
}

