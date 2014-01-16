using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL;

namespace ShopModelMapper
{
    public interface IMapper<TEntity> where TEntity: Entity
    {
        IModel GetModelFromEntity(TEntity entity);
        TEntity GetEntityFromModel(IModel model);
    }
}
