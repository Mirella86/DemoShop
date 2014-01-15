using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL;

namespace ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var dataContext = new DemoShopEntities();
          //  {
                var clothingRepo = new RepositoryBase<Clothing, int>();
                var cosmeticRepo = new RepositoryBase<Cosmetic, int>();

            IQueryable<Clothing> list = clothingRepo.GetAll();

            foreach (var clothing in list)
            {
                Console.WriteLine("{0}: {1}",clothing.Name, clothing.Size);
            }

                Console.ReadKey();
          //  }
        }
    }
}
