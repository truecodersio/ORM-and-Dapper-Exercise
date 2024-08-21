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
        static void Main(string[] args)
        {

            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            //link to sql server 
            //calling the dapper methods

            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(conn);
           
           var departments =  repo.GetDepartments();
            
            foreach(var department in departments)
            {
                Console.WriteLine($" The dept id is:{department.DepartmentID} and the name is: {department.Name}");
                Console.WriteLine("");

            }

            
        }

           
        }
}


