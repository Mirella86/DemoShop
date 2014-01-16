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
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : Entity
    {

      //  protected DemoShopEntities dbContext;
       internal DbSet<TEntity> dbSet;
        private readonly UnitOfWork _unitOfWork;

        public RepositoryBase(UnitOfWork unitOfWork)
        {
            //if (dbContext == null)
            //    dbContext = new DemoShopEntities();
            //dbSet = dbContext.Set<TEntity>();

            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;

            dbSet = _unitOfWork.dbContext.Set<TEntity>();
        }


        public IQueryable<TEntity> GetAll()
        {
            return dbSet.AsQueryable();
        }

        public TEntity Get(int key)
        {
            return dbSet.Find(key);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            _unitOfWork.dbContext.SaveChanges();
          //  dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var updated = dbSet.Attach(entity);
            _unitOfWork.dbContext.Entry(entity).State = EntityState.Modified;
            _unitOfWork.SaveChanges();

        }

        public void Delete(TEntity entity)
        {
            var deleted = dbSet.Attach(entity);
            _unitOfWork.dbContext.Entry(entity).State = EntityState.Deleted;
            _unitOfWork.SaveChanges();
            //         dbContext.Entry(entity).State = EntityState.Deleted;
            //    _unitOfWork.SaveChanges();
            //   dbContext.SaveChanges();
        }
    }
}
