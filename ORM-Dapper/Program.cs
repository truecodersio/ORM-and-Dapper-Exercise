using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;


namespace ORM_Dapper
{
    public class Program
    {

          //allows us to grab the connection string information from the appsettings.json file
        //-----------------------------------------------------------------
        static IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        static string connString = config.GetConnectionString("DefaultConnection");
        //-----------------------------------------------------------------
        static void Main(string[] args)
        {

         IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(conn);
           
               var prodRepo = new DapperProductRepository(conn);
               var products = prodRepo.GetAllProducts();

            //print each product from the products collection to the console
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} {product.Name}");
                Console.WriteLine("");
            }

           
        //    var departments =  repo.GetDepartments();
            
        //     foreach(var department in departments)
        //     {
        //         Console.WriteLine($" The dept id is:{department.DepartmentID} and the name is: {department.Name}");
        //         Console.WriteLine("");

        //     }

            
        }

           
    }
}


