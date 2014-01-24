using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using DBEntities;
using ShopDAL;
using ShopDALServices;
using ShopDomainServices;
using ShopModelMapper;

namespace WebApplicationService
{
    public class WindsorResolver
    {
        private static volatile WindsorResolver instance;
        private static object syncRoot = new Object();
        public static WindsorContainer _container;

        private WindsorResolver()
        {
            InitializeWindsor();
        }

        public static WindsorResolver Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new WindsorResolver();
                    }
                }
                return instance;
            }
        }

        public ICosmeticDomainService CosmeticDomainService
        {
            get { return _container.Resolve<ICosmeticDomainService>(); }
        }

        public IClothingDomainService ClothingDomainService
        {
            get { return _container.Resolve<IClothingDomainService>(); }
        }

        public IClothingBrandDomainService ClothingBrandDomainService
        {
            get { return _container.Resolve<IClothingBrandDomainService>(); }
        }

        public ICosmeticBrandDomainService CosmeticBrandDomainService
        {
            get { return _container.Resolve<ICosmeticBrandDomainService>(); }
        }

        private void InitializeWindsor()
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());

            _container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifeStyle.Transient);
            _container.Register(Component.For(typeof(IDomainService<>)).ImplementedBy(typeof(DomainService<>)).LifeStyle.Transient);
            _container.Register(Component.For(typeof(IMapper<Cosmetic>)).ImplementedBy(typeof(CosmeticMapper)).LifeStyle.Transient);
            _container.Register(Component.For(typeof(IMapper<Clothing>)).ImplementedBy(typeof(ClothingMapper)).LifeStyle.Transient);
            _container.Register(Component.For(typeof(IMapper<Clothing_Brand>)).ImplementedBy(typeof(ClothingBrandMapper)).LifeStyle.Transient);
            _container.Register(Component.For(typeof(IMapper<Cosmetic_Brand>)).ImplementedBy(typeof(CosmeticBrandMapper)).LifeStyle.Transient);
            _container.Register(Component.For<ICosmeticDomainService>().ImplementedBy<CosmeticDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<IClothingDomainService>().ImplementedBy<ClothingDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<IClothingBrandDomainService>().ImplementedBy<ClothingBrandDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<ICosmeticBrandDomainService>().ImplementedBy<CosmeticBrandDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<IEntity>().ImplementedBy<Entity>().LifeStyle.Transient);
        }
    }
}