using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DBEntities;

namespace ShopDAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {

        public IEnumerable<TEntity> GetAll()
        {
            using (var unitOfWork = new UnitOfWork<TEntity>())
            {
                foreach (var element in unitOfWork.dbSet.AsEnumerable())
                {
                    yield return element;
                }
            }
        }


        public IEnumerable<TEntity> GetAllWithChildren(IEnumerable<string> children)
        {
            using (var unitOfWork = new UnitOfWork<TEntity>())
            {
                var entities = unitOfWork.dbSet.AsQueryable<TEntity>();

                foreach (var child in children)
                {
                    entities = entities.Include(child);
                }

                foreach (var element in entities)
                {
                    yield return element;

                }
            }
        }

        public TEntity Get(int key)
        {
            using (var unitOfWork = new UnitOfWork<TEntity>())
            {
                return unitOfWork.dbSet.Find(key);
            }
        }

        public TEntity GetWithChildren(TEntity entity, IEnumerable<string> children)
        {
            using (var unitOfWork = new UnitOfWork<TEntity>())
            {
                IQueryable<TEntity> entities = unitOfWork.dbSet.AsQueryable<TEntity>();

                foreach (var child in children)
                {
                    entities = entities.Include(child);
                }

                foreach (var ent in entities)
                {
                    if (ent.CompareTo(entity))
                        return ent;
                }
                return null;

            }
        }

        public void Insert(TEntity entity)
        {
            using (var unitOfWork = new UnitOfWork<TEntity>())
            {
                unitOfWork.dbSet.Add(entity);
                unitOfWork.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var unitOfWork = new UnitOfWork<TEntity>())
            {
                unitOfWork.dbSet.Attach(entity);
                unitOfWork.ChangeEntityState(entity, EntityState.Modified);
                unitOfWork.SaveChanges();
            }

        }

        public void Delete(int key)
        {
            using (var unitOfWork = new UnitOfWork<TEntity>())
            {
                var entity = unitOfWork.dbSet.Find(key);
                unitOfWork.ChangeEntityState(entity, EntityState.Deleted);
                unitOfWork.SaveChanges();
            }
        }

    }
}
