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
using DBEntities;
using ShopDAL;
using ShopDomainServices;
using ShopModelMapper;
using Component = Castle.MicroKernel.Registration.Component;

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

        private void InitializeWindsor()
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());

            _container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifeStyle.Transient);
            _container.Register(Component.For(typeof(IDomainService<>)).ImplementedBy(typeof(DomainService<>)).LifeStyle.Transient);
            _container.Register(Component.For(typeof(IMapper<Cosmetic>)).ImplementedBy(typeof(CosmeticMapper)).LifeStyle.Transient);
            _container.Register(Component.For(typeof(IMapper<Clothing>)).ImplementedBy(typeof(ClothingMapper)).LifeStyle.Transient);
            _container.Register(Component.For<ICosmeticDomainService>().ImplementedBy<CosmeticDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<IClothingDomainService>().ImplementedBy<ClothingDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<IEntity>().ImplementedBy<Entity>().LifeStyle.Transient);
        }
    }
}