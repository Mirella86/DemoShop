using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using ShopDAL;
using ShopDomainServices;
using ShopModelMapper;

namespace ShopDALServices
{
    public class ClothingBrandDomainService : DomainService<Clothing_Brand>, IClothingBrandDomainService
    {
        public ClothingBrandDomainService(IRepository<Clothing_Brand> repository, IMapper<Clothing_Brand> mapper) : base(repository, mapper)
        {
        }
    }
}
