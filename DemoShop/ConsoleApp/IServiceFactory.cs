using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL;
using ShopDomainServices;

namespace ConsoleApp
{
    public interface IServiceFactory
    {
        T Create<T>()
       where T : IDomainServiceBase<Entity>;

        void Release(IDomainServiceBase<Entity> domainService);
    }
}
