﻿using NUnit.Framework;
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
    public class DepartmentRepositoryTest
    {
        private IDepartmentRepository _departmentRepository;

        [SetUp]
        public void Initialize()
        {
            var context = new AppDBContext(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString);
            _departmentRepository = new DepartmentRepository(context);

        }
        [Test]
        public void must_return_one_record_by_name()
        {
            string Name = "IT";

            var data = _departmentRepository.GetPagedDepartmentByName(Name).ToList();

            if (!data.Any())
            {
                Assert.Warn("There is no data in the table for this test case");
            }

            else
                Assert.IsTrue(data.Any());
        }

        [Test]
        public void must_return_one_record_by_id()
        {
            int id = 1;

            var data = _departmentRepository.GetPagedDepartmentById(id).ToList();

            if (!data.Any())
            {
                Assert.Warn("No record Found!");
            }

            else
                Assert.IsTrue(data.Any());
        }

        [Test]
        public void must_do_paging_by_name()
        {
            int pageSize = 5;
            int pageNo = 2;
            string Name = "HR";

            var data = _departmentRepository.GetPagedDepartmentByName(Name, pageSize, pageNo).ToList();

            if (!data.Any())
            {
                Assert.Warn("No record Found!");
            }

            Assert.IsTrue(data.All(x => x.DepartmentName.ToUpper() == Name.ToUpper()));
        }

        [Test]
        public void must_do_paging_by_id()
        {
            int pageSize = 5;
            int pageNo = 2;
            int id = 2;

            var data = _departmentRepository.GetPagedDepartmentById(id, pageSize, pageNo).ToList();

            if (!data.Any())
            {
                Assert.Warn("No record Found!");
            }

            Assert.IsTrue(data.All(x => x.DepartmentId == id));
        }
    }
}
