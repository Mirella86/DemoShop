using System.Collections.Generic;
using DBEntities;
using ShopModels;


namespace ShopDomainServices
{

    public interface IDomainService<TEntity>  where TEntity : Entity
    {

        IEnumerable<IModel> GetAll();
        IModel Get(int id);
        IModel GetWithChildren(int id, string[] children);
        void Insert(IModel entity);
        void Delete(int entity);
        void Update(IModel entity);
    }
}
