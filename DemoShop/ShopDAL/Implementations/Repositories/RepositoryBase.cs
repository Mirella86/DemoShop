using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL
{
    public class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        //       protected ObjectContext DbContext;
        //      protected ObjectSet<TEntity> DbSet;

        protected DemoShopEntities Context;
        protected DbSet<TEntity> Set;

        public RepositoryBase()
        {
            if (Context == null)
                Context = new DemoShopEntities();
            Set = Context.Set<TEntity>();
        }


        public IQueryable<TEntity> GetAll()
        {
            return Set.AsQueryable();
        }

        public TEntity Get(TPrimaryKey key)
        {
            return Set.Find(key);
        }

        public void Insert(TEntity entity)
        {
            Set.Add(entity);
        }

        public void Update(TEntity entity)
        {
            var updated = Set.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;


        }

        public void Delete(TEntity entity)
        {
            Set.Remove(entity);
        }
    }
}
