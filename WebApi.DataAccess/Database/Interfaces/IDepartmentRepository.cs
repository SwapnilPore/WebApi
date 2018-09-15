using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DataAccess.Database.Entities;

namespace WebApi.DataAccess.Database.Interfaces
{
    public interface IDepartmentRepository :IRepository<Department>
    {
        IQueryable<Department> GetPagedDepartmentByName(string name, int pageSize = 10, int pageNo = 1);
        IQueryable<Department> GetPagedDepartmentById(int id, int pageSize = 15, int pageNo = 1);
        IQueryable<Department> DepartmentPagedData(int pageSize = 15, int pageNo = 1);
    }
}
