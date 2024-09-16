using System;
using System.Collections.Generic;


namespace BestBuyBestPractices;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts(); 
    void CreateProduct(string name, double price, int CategoryID);
    
    
}