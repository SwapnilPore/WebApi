using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DataAccess.Database;
using WebApi.DataAccess.Database.Interfaces;
using WebApi.DataAccess.Database.Repositories;

namespace WebApiUnitTest
{
    public class EmployeeRepositoryTest
    {
        private IEmployeeRepository _employeeRepository;

        [SetUp]
        public void Initialize()
        {
            var context = new AppDBContext(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString);
            _employeeRepository = new EmployeeRepository(context);

        }

        [Test]
        public void must_return_one_record_by_name()
        {
            string Name = "Jack";

            var data = _employeeRepository.GetPagedEmployeeByName(Name).ToList();

            if (!data.Any())
            {
                Assert.Warn("No record found!!");
            }

            else
                Assert.IsTrue(data.Any());
        }

        [Test]
        public void must_return_one_record_by_id()
        {
            int id = 3;

            var data = _employeeRepository.GetPagedEmployeeDataById(id).ToList();

            if (!data.Any())
            {
                Assert.Warn("No record found!!");
            }

            else
                Assert.IsTrue(data.Any());
        }

        [Test]
        public void must_do_paging_by_name()
        {
            int pageSize = 5;
            int pageNo = 1;
            string Name = "Jill";

            var data = _employeeRepository.GetPagedEmployeeByName(Name, pageSize, pageNo).ToList();

            if (!data.Any())
            {
                Assert.Warn("No record found!!");
            }

            Assert.IsTrue(data.All(x => x.EmployeeName.ToUpper() == Name.ToUpper()));
        }

        [Test]
        public void must_do_paging_by_id()
        {
            int pageSize = 5;
            int pageNo = 2;
            int id = 2;

            var data = _employeeRepository.GetPagedEmployeeDataById(id, pageSize, pageNo).ToList();

            if (!data.Any())
            {
                Assert.Warn("No record found!!");
            }

            Assert.IsTrue(data.All(x => x.EmployeeId == id));
        }
    }
}
