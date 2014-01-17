using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using ShopDAL;
using ShopModelMapper;

namespace ShopDomainServices
{

    public interface IDomainService<TEntity>  where TEntity : Entity
    {

        IEnumerable<IModel> GetAll();
        IModel Get(int id);
        void Insert(IModel entity);
        void Delete(int entity);
        void Update(IModel entity);
    }
}
