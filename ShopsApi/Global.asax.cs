using Autofac;
using Autofac.Integration.WebApi;
using CodeFirstEmployee.contexts;
using CodeFirstEmployee.models;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ShopsApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RegisterAutofac();
        }

        private void RegisterAutofac()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();
            //builder.RegisterModule(new DataModule("ShopContext"));
            builder.RegisterType<EmployeeTypeRepository>().As<IRepository<EmployeeType>>();
            builder.RegisterType<EmployeeRepository>().As<IRepository<Employee>>();
            builder.Register(c => new ShopContext("ShopContext")).As<DbContext>().InstancePerRequest();
            builder.Register(c => new ShopContext()).As<DbContext>().InstancePerRequest();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            
        }
    }
}
