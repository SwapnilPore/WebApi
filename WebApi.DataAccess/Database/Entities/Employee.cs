using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.DataAccess.Database.Entities
{
    [Table("Employee",Schema ="dbo")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime EmployeeBirthday { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
