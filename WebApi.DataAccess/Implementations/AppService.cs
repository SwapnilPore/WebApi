using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Contracts.BusinessEntities;
using WebApi.Contracts.Interfaces;
using WebApi.DataAccess.Database.Interfaces;

namespace WebApi.DataAccess.Implementations
{
    public class AppService : IAppService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public AppService(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }
        public IEnumerable<EmployeeModel> GetPagedEmployeeDataById(int id, int pageSize = 10, int pageNo = 1)
        {
            try
            {
                var employeeData = _employeeRepository.GetPagedEmployeeDataById(id, pageSize, pageNo);
                var departmentData = _departmentRepository.GetPagedDepartmentById(id, pageSize, pageNo);

                var employeeModel = from e in employeeData
                                   join d in departmentData
                                   on e.DepartmentId equals d.DepartmentId
                                   select new EmployeeModel
                                   {
                                       EmployeedId = e.EmployeeId,
                                       EmployeeName = e.EmployeeName,
                                       Age = (DateTime.Today.Year - e.EmployeeBirthday.Year),
                                       DepartmentName = d.DepartmentName
                                   };
                return employeeModel.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<EmployeeModel> GetPagedEmployeeDataByName(string name, int pageSize = 10, int pageNo = 1)
        {
            try
            {
                var employeeData = _employeeRepository.GetPagedEmployeeByName(name, pageSize, pageNo).ToList();
                var departmentData = _departmentRepository.DepartmentPagedData(pageSize, pageNo);

                var employeeModel = from e in employeeData
                                    join d in departmentData
                                    on e.DepartmentId equals d.DepartmentId into x
                                    from result in x.DefaultIfEmpty()
                                    select new EmployeeModel
                                    {
                                        EmployeedId = e.EmployeeId,
                                        EmployeeName = e.EmployeeName,
                                        Age = (DateTime.Today.Year - e.EmployeeBirthday.Year),
                                        DepartmentName = result.DepartmentName
                                    };
                return employeeModel.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
