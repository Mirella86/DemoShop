using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using ShopDAL;
using ShopDomainServices;
using ShopModelMapper;
using Castle.Facilities.TypedFactory;

namespace ConsoleApp
{
    public class WindsorFactoryResolver
    {
        private WindsorContainer _container;
        private IKernel _kernel;

        private WindsorFactoryResolver()
        {
            _container = new WindsorContainer();
            _kernel = new DefaultKernel();
            _kernel.AddFacility<TypedFactoryFacility>();
        }

        private void InitializeWindsor()
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());

            _container.Register(
              Component.For(typeof(IRepository<>)).ImplementedBy(typeof(RepositoryBase<>)),
              Component.For<IEntity>().ImplementedBy<Entity>(),
              Component.For<IClothingService>().ImplementedBy<ClothingService>(),
               Component.For<ICosmeticService>().ImplementedBy<CosmeticService>(),
               Component.For(typeof(IMapper<Clothing>)).ImplementedBy(typeof(ClothingMapper)),
               Component.For(typeof(IMapper<Cosmetic>)).ImplementedBy(typeof(CosmeticMapper)),
               Component.For<UnitOfWork>().ImplementedBy<ShopUnitOfWork>(),
              Component.For<IServiceFactory>().AsFactory(),
              Component.For(typeof(IDomainServiceBase<>)).ImplementedBy(typeof(DomainServiceBase<>))
              );


            _container.Register(Castle.MicroKernel.Registration.Component.For(typeof(IRepository<>)).ImplementedBy(typeof(RepositoryBase<>)));
            _container.Register(Castle.MicroKernel.Registration.Component.For(typeof(IDomainServiceBase<>)).ImplementedBy(typeof(DomainServiceBase<>)));
            _container.Register(Castle.MicroKernel.Registration.Component.For(typeof(IMapper<Cosmetic>)).ImplementedBy(typeof(CosmeticMapper)));
            _container.Register(Castle.MicroKernel.Registration.Component.For(typeof(IMapper<Clothing>)).ImplementedBy(typeof(ClothingMapper)));
            _container.Register(Castle.MicroKernel.Registration.Component.For<UnitOfWork>().ImplementedBy<ShopUnitOfWork>());
            _container.Register(Castle.MicroKernel.Registration.Component.For<IEntity>().ImplementedBy<Entity>());

        }
    }
}
