using DBEntities;
using ShopModels;

namespace ShopModelMapper
{
    public interface IMapper<TEntity> where TEntity: Entity
    {
        IModel GetModelFromEntity(TEntity entity);
        TEntity GetEntityFromModel(IModel model);
        TEntity GetEntityFromModelKey(int key);
    }
}
