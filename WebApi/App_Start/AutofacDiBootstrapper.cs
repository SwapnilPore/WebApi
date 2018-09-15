using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi.Controllers;

namespace WebApi
{
    public static class AutofacDiBootstrapper
    {
        public static void Bootsrap()
        {
            var containerBuilder = new ContainerBuilder();
            SetupRegistration.Bootstrap(containerBuilder);
            containerBuilder.RegisterApiControllers(typeof(EmployeeController).Assembly);
            var container = containerBuilder.Build();
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
        }
    }
}