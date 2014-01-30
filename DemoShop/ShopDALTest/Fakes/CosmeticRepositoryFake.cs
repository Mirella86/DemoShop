using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopDAL;

namespace ShopDALTest.Fakes
{
    public class CosmeticRepositoryFake : ICosmeticRepository
    {
        public List<Cosmetic> _cosmeticFakeList;

        public CosmeticRepositoryFake()
        {
            _cosmeticFakeList = new List<Cosmetic>();
            _cosmeticFakeList.Add(new Cosmetic { Name = "product1", Id = 1, Stock = 10, BrandId = 11, CategoryId = 111 });
            _cosmeticFakeList.Add(new Cosmetic { Name = "product2", Id = 2, Stock = 20, BrandId = 22, CategoryId = 222 });
        }

        public IEnumerable<Cosmetic> GetAll()
        {
            return _cosmeticFakeList.ToList();
        }

        public IEnumerable<Cosmetic> GetAllWithChildren(IEnumerable<string> children)
        {
            throw new NotImplementedException();
        }

        public Cosmetic Get(int key)
        {
            return _cosmeticFakeList.SingleOrDefault(item => item.Id == key);
        }

        public Cosmetic GetWithChildren(Cosmetic entity, IEnumerable<string> children)
        {
            throw new NotImplementedException();
        }

        public void Insert(Cosmetic entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Cosmetic entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }
    }
}
