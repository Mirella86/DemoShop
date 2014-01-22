using DBEntities;
using ShopModels;

namespace ShopModelMapper
{
    public interface IMapper<TEntity> where TEntity: Entity
    {
        Model GetModelFromEntity(TEntity entity);
        TEntity GetEntityFromModel(Model model);
        TEntity GetEntityFromModelKey(int key);
    }
}
