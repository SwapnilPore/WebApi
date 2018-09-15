using Autofac;
using System.Configuration;
using WebApi.DataAccess.Database;
using WebApi.DataAccess.Database.Interfaces;
using WebApi.DataAccess.Database.Repositories;
using WebApi.DataAccess.Implementations;

namespace WebApi
{
    public static class SetupRegistration
    {
        internal static void Bootstrap(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<AppDBContext>()
                .InstancePerRequest()
                .UsingConstructor(typeof(string))
                .WithParameter("connectionSring", ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString);

            containerBuilder.RegisterGeneric(typeof(BaseRepository<,>))
                .As(typeof(IRepository<>))
                .InstancePerRequest();

            containerBuilder.RegisterType<DepartmentRepository>()
                .AsImplementedInterfaces()
                .InstancePerRequest()
                .PropertiesAutowired();

            containerBuilder.RegisterType<EmployeeRepository>()
                .AsImplementedInterfaces()
                .InstancePerRequest()
                .PropertiesAutowired();

            containerBuilder.RegisterType<AppService>()
                .AsImplementedInterfaces()
                .InstancePerRequest();
        }
    }
}