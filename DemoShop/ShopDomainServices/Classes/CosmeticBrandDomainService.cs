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
    public class CosmeticBrandDomainService : DomainService<Cosmetic_Brand>, ICosmeticBrandDomainService
    {
        public CosmeticBrandDomainService(IRepository<Cosmetic_Brand> repository, IMapper<Cosmetic_Brand> mapper) : base(repository, mapper)
        {
        }
    }
}
