using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using ShopDAL;
using ShopDALServices;
using ShopModelMapper;

namespace WebApplicationService
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        public static WindsorContainer _container;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeWindsor();
        }

        private static void InitializeWindsor()
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());

            _container.Register(Castle.MicroKernel.Registration.Component.For(typeof(IRepository<>)).ImplementedBy(typeof(RepositoryBase<>)));
            _container.Register(Castle.MicroKernel.Registration.Component.For(typeof(IDALServiceBase<>)).ImplementedBy(typeof(DALServiceBase<>)));
            _container.Register(Castle.MicroKernel.Registration.Component.For(typeof(IMapper<Cosmetic>)).ImplementedBy(typeof(CosmeticMapper)));
            _container.Register(Castle.MicroKernel.Registration.Component.For(typeof(IMapper<Clothing>)).ImplementedBy(typeof(ClothingMapper)));
            _container.Register(Castle.MicroKernel.Registration.Component.For<UnitOfWork>().ImplementedBy<ShopUnitOfWork>());
            _container.Register(Castle.MicroKernel.Registration.Component.For<IEntity>().ImplementedBy<Entity>());

            }
    }
}