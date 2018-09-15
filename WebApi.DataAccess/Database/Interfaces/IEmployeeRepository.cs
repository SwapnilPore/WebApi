using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DataAccess.Database.Entities;

namespace WebApi.DataAccess.Database.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IQueryable<Employee> GetPagedEmployeeByName(string name, int pageSize = 10, int pageNo = 1);
        IEnumerable<Employee> GetPagedEmployeeDataById(int id, int pageSize = 10, int pageNo = 1);
    }
}
