using System;
using System.Collections.Generic;
using DBEntities;
using ShopDAL;
using ShopModelMapper;

namespace ShopDomainServices
{
    public class DomainService<TEntity> : IDomainService<TEntity> where TEntity : Entity
    {
        protected IRepository<TEntity> _repository;
        protected IMapper<TEntity> _mapper;

        public DomainService(IRepository<TEntity> repository, IMapper<TEntity> mapper)
        {
            if (repository == null || mapper == null)
                throw new ArgumentNullException("repository");

            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<IModel> GetAll()
        {
            IEnumerable<TEntity> modelsList = _repository.GetAll();
            foreach (var entity in modelsList)
            {
                yield return _mapper.GetModelFromEntity(entity);
            }
        }

        public IModel Get(int id)
        {
            return _mapper.GetModelFromEntity(_repository.Get(id));
        }


        public void Insert(IModel model)
        {
            _repository.Insert(_mapper.GetEntityFromModel(model));
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Update(IModel model)
        {
            _repository.Update(_mapper.GetEntityFromModel(model));
        }
    }
}
