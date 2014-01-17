using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DBEntities;

namespace ShopDAL
{
    public class UnitOfWork<TEntity> : IDisposable where TEntity : Entity
    {
        private DbContext _dbContext;
        public DbSet<TEntity> dbSet;

        public UnitOfWork()
        {
            _dbContext = new DemoShopEntities();
            dbSet = _dbContext.Set<TEntity>();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void ChangeEntityState(TEntity entity, EntityState state)
        {
            _dbContext.Entry(entity).State = state;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }


}
