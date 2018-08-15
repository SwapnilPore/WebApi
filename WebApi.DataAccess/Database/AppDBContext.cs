using System.Data.Entity;
using WebApi.DataAccess.Database.Entities;

namespace WebApi.DataAccess.Database
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(string connectionSring) : base(connectionSring)
        {
            System.Data.Entity.Database.SetInitializer<AppDBContext>(null);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
