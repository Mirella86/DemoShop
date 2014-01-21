using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;

namespace ShopDAL
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllWithChildren(IEnumerable<string> children);
        TEntity Get(int key);
        TEntity GetWithChildren(TEntity entity, IEnumerable<string> children);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int key);

    }
}
