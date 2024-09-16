using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using BestBuyBestPractices;

class Program
{
    static IConfiguration config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

    static string connString = config.GetConnectionString("DefaultConnection");
    //-----------------------------------------------------------------

    //create our IDbConnection that uses MySql, so Dapper can extend it
    static IDbConnection conn = new MySqlConnection(connString);


    static void Main(String[] args)
    {


        //Department Section
        IDbConnection conn = new MySqlConnection(connString);
        DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);

        Console.WriteLine("Hello user, here are the current departments");
        Console.WriteLine("Please press enter  .....");
        Console.ReadLine();

        var depos = repo.GetAllDepartments();
        Print(depos);


        Console.WriteLine("Do you want to add a department?");
        var userReponse = Console.ReadLine();

        if (userReponse.ToLower() == "yes")
        {
            Console.WriteLine("What is the name of the department you want to add?");
            userReponse = Console.ReadLine();
            repo.InsertDepartment(userReponse);
            Print(repo.GetAllDepartments());
        }

        Console.WriteLine("Have a great day!");
        
        ListProducts();
        
        CreateAndListProducts();
        


    }

    private static void Print(IEnumerable<Department> depos)
    {
        foreach (var depo in depos)
        {
            Console.WriteLine($"Id: {depo.DepartmentID} Name: {depo.Name}");
        }
    }
    
    
    public static void ListProducts()
    {
        var prodRepo = new DapperProductRepository(conn);
        
        Console.WriteLine("Hello user, here are the current departments");
        Console.WriteLine("Please press enter  .....");
        Console.ReadLine();
        
        var products = prodRepo.GetAllProducts();

        //print each product from the products collection to the console
        foreach (var product in products)
        {
            Console.WriteLine($"{product.ProductID} {product.Name}");
        }
    }

    
    
    
    
    
    
    public static void CreateAndListProducts()
    {
        //created instance so we can call methods that hit the database
        var prodRepo = new DapperProductRepository(conn);
        
        Console.WriteLine("Do you want to add a product?");
        var userinput = Console.ReadLine();

        if (userinput.ToLower() == "yes")
        {
            Console.WriteLine($"What is the new product name?");
           
        }
        else
        {
            Console.WriteLine("Have a great day!");
            return;
        }
        
        string prodName = Console.ReadLine();
        

        Console.WriteLine($"What is the new product's price?");
        var price = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine($"What is the new product's category id?");
        var categoryID = Convert.ToInt32(Console.ReadLine());

        prodRepo.CreateProduct(prodName, price, categoryID);


        //call the GetAllProducts method using that instance and store the result
        //in the products variable
        var products = prodRepo.GetAllProducts();

        //print each product from the products collection to the console
        foreach (var product in products)
        {
            Console.WriteLine($"{product.ProductID} {product.Name}");
        }
        
        Console.WriteLine("Have a great day!");
    }
    




}



