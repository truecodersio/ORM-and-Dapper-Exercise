using System;
using System.Data;
using Dapper;
namespace ORM_Dapper
{
	public class DapperProductRepository : IProductRepository
	{
		//Private readonly conneciton so that it cant be changed after being initialized
		 private readonly IDbConnection _conn;

		public DapperProductRepository(IDbConnection connection)
		{
			connection = _conn;
		}

        public void CreateProduct(string name, double price, int categoryID)
        {
			//_conn.Execute("INSERT INTO departments Name Values(@name);", new { name = name });
             _conn.Execute("INSERT INTO products Name Values(@name);" , new {name = name});
        }

        public IEnumerable<Product> GetAllProducts()
        {
		  return _conn.Query<Product>("SELECT * FROM products");
        }
		public IEnumerable<Product> UpdateProduct()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Product> DeleteProduct()
		{
			throw new NotImplementedException();
		}
    }
}

