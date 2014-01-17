﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DBEntities;

namespace ShopDAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
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

        public TEntity Get(int key)
        {
            using (var unitOfWork = new UnitOfWork<TEntity>())
            {
                return unitOfWork.dbSet.Find(key);
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
