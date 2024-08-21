using System;
using System.Data;
using Dapper;
namespace ORM_Dapper
{
	public class DapperProductRepository : IProductRepository
	{
		//Private readonly conneciton so that it cant be changed after being initialized
		private readonly IDbConnection _connection;

        //constructor - and will do some setup work for us
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
			//the @ variables inside the sql statement should all match the 
			//arguments of the method e.g string name = @name
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) " +
                                "VALUES (@name, @price, @categoryID);"
                , new {name = name, price = price, categoryID = categoryID});
        }

			//dapper extends idbconnections
			//dapper locates the connection and uses .notation to extend functionality

        //Read data
        
            public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }
        
		public void UpdateProductName(int productID, string updatedName)
        {
            _connection.Execute("UPDATE products SET Name = @updatedName WHERE ProductID = @productID;",
                new { updatedName = updatedName, productID = productID });
        }

		 public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
                new { productID = productID });

            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID;",
               new { productID = productID });

            _connection.Execute("DELETE FROM products WHERE ProductID = @productID;",
               new { productID = productID });
        }

		
    }
}

