using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShopDAL.Model;
using ShopDALRepository.Interfaces;

namespace ShopDAL.Repository
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected ShopContext context;
		protected DbSet<TEntity> dbSet;

		public Repository(string connectionString)
		{
            if (context == null)
            {
                context = new ShopContext(connectionString);
            }
			
			this.dbSet = context.Set<TEntity>();
		}
        public Repository(ShopContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public object CurrentContext
        {
            get { return (object)this.context; }
        }

		public IQueryable<TEntity> Entities
		{
			get { return dbSet; }
		}

		public virtual TEntity GetById(object id)
		{
			return dbSet.Find(id);
		}

		public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> filter = null)
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}
			return query;
		}

		public virtual IQueryable<TEntity> Get(
		   Expression<Func<TEntity, bool>> filter = null,
		   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
		   string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				return orderBy(query);
			}
			else
			{
				return query;
			}
		}


		public virtual void Insert(TEntity entity)
		{
			dbSet.Add(entity);
		}

		public virtual void Delete(object id)
		{
			TEntity entityToDelete = dbSet.Find(id);
			Delete(entityToDelete);
		}

		public virtual void Delete(TEntity entityToDelete)
		{
			if (context.Entry(entityToDelete).State == EntityState.Detached)
			{
				dbSet.Attach(entityToDelete);
			}
			dbSet.Remove(entityToDelete);
		}

		public virtual void Update(TEntity entityToUpdate)
		{
			dbSet.Attach(entityToUpdate);
			context.Entry(entityToUpdate).State = EntityState.Modified;
		}

		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
