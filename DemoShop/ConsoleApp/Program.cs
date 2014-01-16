using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
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
            //var dataContext = new DemoShopEntities();

            //var clothingRepo = new RepositoryBase<Clothing>(ShopUnitOfWork.Instance);
            ////     var cosmeticRepo = new RepositoryBase<Cosmetic>(ShopUnitOfWork.Instance);

            //clothingRepo.Insert(new Clothing { Name = "Blouse", Size = "48" });


            //IQueryable<Clothing> list = clothingRepo.GetAll();

            //foreach (var clothing in list)
            //{
            //    Console.WriteLine("{0}: {1}", clothing.Name, clothing.Size);
            //}

            //Console.ReadKey();


            InitializeWindsor();

            //   IRepository<Clothing> repository = _container.Resolve<IRepository<Clothing>>();


           IDomainServiceBase<Clothing> clothingService = _container.Resolve<IDomainServiceBase<Clothing>>();
            clothingService.Insert(new ClothingModel { Name = "Lee Cooper jeans blabla", Size = "34" });

            IEnumerable<IModel> clothingModels = clothingService.GetAll();

            foreach (var clothing in clothingModels)
            {
                Console.WriteLine("{0}: {1}", ((ClothingModel)clothing).Name, ((ClothingModel)clothing).Size);
            }
            Console.WriteLine();

            //var cloth = clothingModels.ElementAt(1);
            //Console.WriteLine("Deleting element: {0}", ((ClothingModel)cloth).Name);
            //clothingService.Delete(clothingModels.ElementAt(1));

            //Console.WriteLine();
            //clothingModels = clothingService.GetAll();

            foreach (var clothing in clothingModels)
            {
                Console.WriteLine("{0}: {1}", ((ClothingModel)clothing).Name, ((ClothingModel)clothing).Size);
            }
            Console.WriteLine();

            IDomainServiceBase<Cosmetic> cosmeticService = _container.Resolve<IDomainServiceBase<Cosmetic>>();
            IModel cosmetic = cosmeticService.Get(1);
            Console.WriteLine("{0}: {1}", ((CosmeticModel)cosmetic).Name, cosmetic.Id);

        }

        private static void InitializeWindsor()
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());

            _container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(RepositoryBase<>)).LifeStyle.Transient);
            _container.Register(Component.For(typeof(IDomainServiceBase<>)).ImplementedBy(typeof(DomainServiceBase<>)).LifeStyle.Transient);
            _container.Register(Component.For(typeof(IMapper<Cosmetic>)).ImplementedBy(typeof(CosmeticMapper)).LifeStyle.Transient);
            _container.Register(Component.For(typeof(IMapper<Clothing>)).ImplementedBy(typeof(ClothingMapper)).LifeStyle.Transient);
            _container.Register(Component.For<UnitOfWork>().ImplementedBy<ShopUnitOfWork>().LifeStyle.Transient);
            _container.Register(Component.For<IEntity>().ImplementedBy<Entity>().LifeStyle.Transient);


        }
    }
}
