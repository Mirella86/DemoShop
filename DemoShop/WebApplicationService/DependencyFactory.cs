using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
using Castle.Windsor.Installer;
using ShopDAL;
using ShopDomainServices;
using ShopModelMapper;

namespace WebApplicationService
{
    public class DependencyFactory
    {
        private WindsorContainer _container;

        private static volatile DependencyFactory instance;
        private static object syncRoot = new Object();

        private DependencyFactory()
        {
            InitializeWindsor();
        }

        public static DependencyFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DependencyFactory();
                    }
                }
                return instance;
            }
        }

        private void InitializeWindsor()
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());

            _container.Register(Castle.MicroKernel.Registration.Component.For(typeof(IRepository<>)).ImplementedBy(typeof(RepositoryBase<>)));
            _container.Register(Castle.MicroKernel.Registration.Component.For(typeof(IDomainServiceBase<>)).ImplementedBy(typeof(DomainServiceBase<>)));
            _container.Register(Castle.MicroKernel.Registration.Component.For(typeof(IMapper<Cosmetic>)).ImplementedBy(typeof(CosmeticMapper)));
            _container.Register(Castle.MicroKernel.Registration.Component.For(typeof(IMapper<Clothing>)).ImplementedBy(typeof(ClothingMapper)));
            _container.Register(Castle.MicroKernel.Registration.Component.For<UnitOfWork>().ImplementedBy<ShopUnitOfWork>());
            _container.Register(Castle.MicroKernel.Registration.Component.For<IEntity>().ImplementedBy<Entity>());

        }

    }
}