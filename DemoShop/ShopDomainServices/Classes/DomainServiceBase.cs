using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL;
using ShopDomainServices;
using ShopModelMapper;

namespace ShopDomainServices
{
    public class DomainServiceBase<TEntity> : IDomainServiceBase<TEntity> where TEntity : Entity
    {
        protected IRepository<TEntity> _repository;
        protected IMapper<TEntity> _mapper;

        public DomainServiceBase(IRepository<TEntity> repository, IMapper<TEntity> mapper)
        {
            if (repository == null || mapper == null)
                throw new ArgumentNullException("repository");

            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<IModel> GetAll()
        {
            foreach (var entity in _repository.GetAll())
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

        public void Delete(IModel  model)
        {
            _repository.Delete(_mapper.GetEntityFromModel(model));
        }

        public void Update(IModel model)
        {
            _repository.Update(_mapper.GetEntityFromModel(model));
        }
    }
}
