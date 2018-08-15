using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.DataAccess.Database.Entities
{
    [Table("Department",Schema ="dbo")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<Employee> Employee { get; set; }
    }
}
