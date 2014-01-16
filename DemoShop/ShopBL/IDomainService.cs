using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopModelMapper;

namespace ShopBL
{
    public interface IDomainService<TModel> where TModel: class 
    {

        IEnumerable<IModel> GetAll();
        IModel Get(int id);
        void Insert(IModel entity);
        void Delete(IModel entity);
        void Update(IModel entity);
    }
}
