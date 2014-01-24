using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using ShopDAL;
using ShopModelMapper;
using ShopModels;

namespace ShopDomainServices
{
    public class ClothingDomainService : DomainService<Clothing>, IClothingDomainService
    {
        protected IClothingRepository _repository;
        protected ClothingMapper _mapper;

        public ClothingDomainService(IRepository<Clothing> repository, IMapper<Clothing> mapper)
            : base(repository, mapper)
        {
        //    _repository = (IClothingRepository)repository;
        //    _mapper = (ClothingMapper)mapper;
        }

        //public override void Update(Model model)
        //{
        //    _repository.Update(_mapper.GetEntityFromModel(model));


        //}
    }
}
