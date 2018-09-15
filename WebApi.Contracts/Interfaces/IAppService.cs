using System;
using System.Collections.Generic;
using WebApi.Contracts.BusinessEntities;

namespace WebApi.Contracts.Interfaces
{
    public interface IAppService
    {
        IEnumerable<EmployeeModel> GetPagedEmployeeDataById(int id, int pageSize = 10, int pageNo = 1);
        IEnumerable<EmployeeModel> GetPagedEmployeeDataByName(string name, int pageSize = 10, int pageNo = 1);
    }
}
