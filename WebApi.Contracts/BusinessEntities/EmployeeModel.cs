using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Contracts.BusinessEntities
{
    public class EmployeeModel
    {
        public int EmployeedId { get; set; }
        public string EmployeeName { get; set; }
        public int Age { get; set; }
        public string DepartmentName { get; set; }
    }
}
