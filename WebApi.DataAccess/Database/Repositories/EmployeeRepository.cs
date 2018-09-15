using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DataAccess.Database.Entities;
using WebApi.DataAccess.Database.Interfaces;

namespace WebApi.DataAccess.Database.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, AppDBContext>, IEmployeeRepository
    {
        private readonly AppDBContext _context;

        public EmployeeRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Employee> GetPagedEmployeeByName(string name, int pageSize = 10, int pageNo = 1)
        {
            var query = EmployeePagedData(pageSize, pageNo).Where(x => x.EmployeeName.ToUpper() == name.ToUpper());
            return query;
        }

        public IEnumerable<Employee> GetPagedEmployeeDataById(int id, int pageSize = 10, int pageNo = 1)
        {
            var query = EmployeePagedData(pageSize, pageNo).Where(x => x.EmployeeId == id);
            return query;
        }

        public IQueryable<Employee> EmployeePagedData(int pageSize = 15, int pageNo = 1)
        {
            var query = _context.Employees.OrderBy(x => x.EmployeeId).Skip((pageNo - 1) * pageSize).Take(pageSize);
            return query;

        }
        
    }
}
