using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Text;


namespace BestBuyBestPractices;

public class DapperProductRepository : IProductRepository
{
    
    private readonly IDbConnection _connection;

    public DapperProductRepository(IDbConnection connection)
    {
        
        _connection = connection;
        
    }


    //Create data
    public void CreateProduct(string name, double price, int categoryID)
    {
        _connection.Execute("INSERT INTO products (Name, Price, CategoryID) " +
                            "VALUES (@name, @price, @categoryID);"
            , new {name = name, price = price, categoryID = categoryID});
    }

    //Read data
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM products;");
    }

   

   
}