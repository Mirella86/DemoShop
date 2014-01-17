using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using DBEntities;
using ShopDAL;
using ShopDomainServices;
using ShopModelMapper;

namespace ConsoleApp
{
    class Program
    {
        private static WindsorContainer _container;

        public static void Main(string[] args)
        {

            InitializeWindsor();

            IClothingDomainService clothingDomainService = _container.Resolve<IClothingDomainService>();
            IEnumerable<IModel> clothingModels = clothingDomainService.GetAll();
            clothingDomainService.Insert(new ClothingModel { Name = "H&M pants", Size = "34" });
            clothingDomainService.Delete(18);
            foreach (var clothing in clothingModels)
            {
                Console.WriteLine("{0}: {1}", ((ClothingModel)clothing).Name, ((ClothingModel)clothing).Size);
            }

            //      IDomainServiceBase<Clothing> clothingService = _container.Resolve<IDomainServiceBase<Clothing>>();
            //        clothingService.Insert(new ClothingModel { Name = "Lee Cooper jeans blabla", Size = "34" });

            //        IEnumerable<IModel> clothingModels = clothingService.GetAll();

            //foreach (var clothing in clothingModels)
            //{
            //    Console.WriteLine("{0}: {1}", ((ClothingModel)clothing).Name, ((ClothingModel)clothing).Size);
            //}
            //Console.WriteLine();


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
