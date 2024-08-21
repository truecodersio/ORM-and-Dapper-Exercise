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
			//_conn.Execute("INSERT INTO departments Name Values(@name);", new { name = name });
             _connection.Execute("INSERT INTO products Name Values(@name);" , new {name = name});
        }

			//dapper extends idbconnections
			//dapper locates the connection and uses .notation to extend functionality

        //Read data
        
            public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
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

