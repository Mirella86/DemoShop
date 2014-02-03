using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using DBEntities;
using ShopDAL;
using ShopDALServices;
using ShopDALServices.Classes;
using ShopDomainServices;
using ShopModelMapper;
using ShopModels;

namespace WebApplicationService
{
    public class WindsorResolver
    {
        private static volatile WindsorResolver instance;
        private static object syncRoot = new Object();
        private static WindsorContainer _container;

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

        public IDomainService GetInstanceOfDomainService(Model model)
        {

            Type modelType = model.GetType();
            if (modelType == typeof(ClothingModel))
                return _container.Resolve<IClothingDomainService>();
            if (modelType == typeof(ClothingBrandModel))
                return _container.Resolve<IClothingBrandDomainService>();
            if (modelType == typeof(ClothingCategoryModel))
                return _container.Resolve<IClothingCategoryDomainService>();
            if (modelType == typeof(GenderModel))
                return _container.Resolve<IGenderDomainService>();
            if (modelType == typeof (StockModel))
                return _container.Resolve<IClothingStockDomainService>();

            if (modelType == typeof(CosmeticModel))
                return _container.Resolve<ICosmeticDomainService>();
            if (modelType == typeof(CosmeticBrandModel))
                return _container.Resolve<ICosmeticBrandDomainService>();
            if (modelType == typeof(CosmeticCategoryModel))
                return _container.Resolve<ICosmeticCategoryDomainService>();
            return null;
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
            _container.Register(Component.For(typeof(IMapper<Clothing_Stock>)).ImplementedBy(typeof(StockMapper)).LifeStyle.Transient);

            _container.Register(Component.For<ICosmeticDomainService>().ImplementedBy<CosmeticDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<IClothingDomainService>().ImplementedBy<ClothingDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<IClothingBrandDomainService>().ImplementedBy<ClothingBrandDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<ICosmeticBrandDomainService>().ImplementedBy<CosmeticBrandDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<IClothingCategoryDomainService>().ImplementedBy<ClothingCategoryDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<ICosmeticCategoryDomainService>().ImplementedBy<CosmeticCategoryDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<IGenderDomainService>().ImplementedBy<GenderDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<IClothingStockDomainService>().ImplementedBy<ClothingStockDomainService>().LifeStyle.Transient);
            _container.Register(Component.For<IEntity>().ImplementedBy<Entity>().LifeStyle.Transient);
        }
    }
}