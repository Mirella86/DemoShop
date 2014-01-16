using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL;
using ShopModelMapper;

namespace ShopDALServices
{

    public interface IDALServiceBase<TEntity>  where TEntity : Entity
    {

        IEnumerable<IModel> GetAll();
        IModel Get(int id);
        void Insert(IModel entity);
        void Delete(IModel entity);
        void Update(IModel entity);
    }
}
