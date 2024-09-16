using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Text;


namespace BestBuyBestPractices;


public class DapperDepartmentRepository : IDepartmentRepository
{

    private readonly IDbConnection _connection;

    public DapperDepartmentRepository(IDbConnection connection)
    {
        _connection = connection;

    }

    public IEnumerable<Department> GetAllDepartments()
    {
        
        var depos = _connection.Query<Department>("SELECT * FROM departments").ToList();
        
        return depos;
    }

    public void InsertDepartment(string newDepartmentName)
    {
        _connection.Execute("INSERT INTO departments (Name) VALUES (@departmentName);",
            new {DepartmentName = newDepartmentName});
    }
    
}