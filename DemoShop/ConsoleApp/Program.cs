using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using DBEntities;
using ShopDAL;
using ShopDomainServices;
using ShopModelMapper;
using ShopModels;

namespace ConsoleApp
{
    class Program
    {
        private static WindsorContainer _container;

        public static void Main(string[] args)
        {

            InitializeWindsor();

            var clothingDomainService = _container.Resolve<IClothingDomainService>();
            var children=new string[]{"Clothing_Brand", "Clothing_Category", "Clothing_Gender", "Clothing_Stock"};
            IModel model = clothingDomainService.GetWithChildren(3, children);

            Console.WriteLine();


        }

        private static void InitializeWindsor()
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
