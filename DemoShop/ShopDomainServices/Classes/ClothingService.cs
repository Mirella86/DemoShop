using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL;
using ShopModelMapper;

namespace ShopDomainServices
{
    public class ClothingService : DomainServiceBase<Clothing>, IClothingService
    {
        public ClothingService(IRepository<Clothing> repository, IMapper<Clothing> mapper) : base(repository, mapper)
        {
        }
    }
}
