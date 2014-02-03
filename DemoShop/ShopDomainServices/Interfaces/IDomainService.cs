using System.Collections.Generic;
using DBEntities;
using ShopModels;


namespace ShopDomainServices
{
    public interface IDomainService
    {
        IEnumerable<Model> GetAll();
        Model Get(int id);
        Model GetWithChildren(int id, string[] children);
        void Insert(Model entity);
        void Delete(int entity);
        void Update(Model entity);
    }

    public interface IDomainService<TEntity> : IDomainService where TEntity : class,  IEntity
    {
    }
}
