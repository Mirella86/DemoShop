using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using ShopDAL;
using ShopModelMapper;

namespace ShopDomainServices
{
    public class ClothingDomainService : DomainService<Clothing>, IClothingDomainService
    {
        public ClothingDomainService(IRepository<Clothing> repository, IMapper<Clothing> mapper) : base(repository, mapper)
        {
        }
    }
}
