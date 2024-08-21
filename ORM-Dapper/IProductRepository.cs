using System;
namespace ORM_Dapper
{
	public interface IProductRepository
	{
		//The methods that the DapperProductRepository will have to inherit from 
		IEnumerable<Product> GetAllProducts(); //stubbed method	
void CreateProduct(string name, double price, int categoryID); //stubbed method

		
	}
}

