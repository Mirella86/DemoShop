using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using ShopDAL;

namespace ShopDALTest.Fakes
{
    public class CosmeticRepositoryFake :ICosmeticRepository
    {

        public IEnumerable<Cosmetic> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cosmetic> GetAllWithChildren(IEnumerable<string> children)
        {
            throw new NotImplementedException();
        }

        public Cosmetic Get(int key)
        {
            throw new NotImplementedException();
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
