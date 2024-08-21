using System;
namespace ORM_Dapper
{
	public interface IDepartmentRepository
	{
		IEnumerable<Department> GetDepartments();
        void CreateDepartment(string Name);
	}
}

