using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL;
using ShopModelMapper;

namespace ShopDomainServices
{
    public interface IDomainServiceBase
    {
    }

    public interface IDomainServiceBase<TEntity> : IDomainServiceBase where TEntity : Entity
    {

        IEnumerable<IModel> GetAll();
        IModel Get(int id);
        void Insert(IModel entity);
        void Delete(IModel entity);
        void Update(IModel entity);
    }
}
