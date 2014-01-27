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

        public IClothingCategoryDomainService ClothingCategoryDomainService
        {
            get { return _container.Resolve<IClothingCategoryDomainService>(); }
        }

        public ICosmeticCategoryDomainService CosmeticCategoryDomainService
        {
            get { return _container.Resolve<ICosmeticCategoryDomainService>(); }
        }

        public IGenderDomainService GenderDomainService {
            get { return _container.Resolve<IGenderDomainService>(); } 
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
            _container.Register(Component.For(typeof(IMapper<Clothing_Category>)).ImplementedBy(typeof(ClothingCategoryMapper)).LifeStyle.Transient);
            _container.Register(Component.For(typeof(IMapper<Cosmetic_Category>)).ImplementedBy(typeof(CosmeticCategoryMapper)).LifeStyle.Transient);
            _container.Register(Component.For(typeof(IMapper<Clothing_Gender>)).ImplementedBy(typeof(ClothingGenderMapper)).LifeStyle.Transient);

            _container.Register(Component.For<ICosmeticDomainService>().ImplementedBy<CosmeticDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<IClothingDomainService>().ImplementedBy<ClothingDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<IClothingBrandDomainService>().ImplementedBy<ClothingBrandDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<ICosmeticBrandDomainService>().ImplementedBy<CosmeticBrandDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<IClothingCategoryDomainService>().ImplementedBy<ClothingCategoryDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<ICosmeticCategoryDomainService>().ImplementedBy<CosmeticCategoryDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<IGenderDomainService>().ImplementedBy<GenderDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<IEntity>().ImplementedBy<Entity>().LifeStyle.Transient);
        }
    }
}