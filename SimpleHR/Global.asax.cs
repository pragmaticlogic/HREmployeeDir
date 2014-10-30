using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using SimpleHR.DataAccess;
using Ninject;
using Ninject.Web.Common;
using SimpleHR.Providers;
using Ninject.Modules;

namespace SimpleHR
{
    internal class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory(IKernel kernel)
        {
            ninjectKernel = kernel;
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (controllerType == null) ? null : (IController)ninjectKernel.Get(controllerType);
        }
    }

    public class MvcApplication : NinjectHttpApplication
    {
        //http://stackoverflow.com/questions/5078046/ninject-and-mvc3-dependency-injection-to-action-filters
        private class AppNinjectModule : NinjectModule
        {
            public override void Load()
            {
                Bind<IRolesCheckProvider>().To<RolesCheckProvider>();                
            }
        }

        protected override IKernel CreateKernel()
        {
            var modules = new INinjectModule[] {
                new AppNinjectModule()
            };

            IKernel kernel = new StandardKernel();

            kernel.Load(System.Reflection.Assembly.GetExecutingAssembly());

            kernel.Bind<ILoginProvider>().To<LoginProvider>();
            kernel.Bind<IRolesCheckProvider>().To<RolesCheckProvider>();            

            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<EmployeeDbContext>(null);
            EmployeeDbContext EmployeeDbContext = new EmployeeDbContext();
            EmployeeDbContext.Database.Initialize(true);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(CreateKernel()));
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
