﻿using System;
using System.Collections.Generic;
using DBEntities;
using ShopDAL;
using ShopModelMapper;
using ShopModels;

namespace ShopDomainServices
{
    public class DomainService<TEntity> : IDomainService<TEntity> where TEntity : class, IEntity
    {
        private IRepository<TEntity> _repository;
        private IMapper<TEntity> _mapper;

        public DomainService(IRepository<TEntity> repository, IMapper<TEntity> mapper)
        {
            if (repository == null || mapper == null)
                throw new ArgumentNullException("repository");

            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<Model> GetAll()
        {
            IEnumerable<TEntity> modelsList = _repository.GetAll();
            foreach (var entity in modelsList)
            {
                yield return _mapper.GetModelFromEntity(entity);
            }
        }

        public Model Get(int id)
        {
            return _mapper.GetModelFromEntity(_repository.Get(id));
        }

        public Model GetWithChildren(int id, string[] children)
        {
            return _mapper.GetModelFromEntity(_repository.GetWithChildren(_mapper.GetEntityFromModelKey(id), children));
        }

        public void Insert(Model model)
        {
            _repository.Insert(_mapper.GetEntityFromModel(model));
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public virtual void Update(Model model)
        {
            _repository.Update(_mapper.GetEntityFromModel(model));
        }
    }
}
