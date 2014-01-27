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
    public class CosmeticCategoryDomainService :DomainService<Cosmetic_Category>, ICosmeticCategoryDomainService
    {
        public CosmeticCategoryDomainService(IRepository<Cosmetic_Category> repository, IMapper<Cosmetic_Category> mapper) : base(repository, mapper)
        {
        }
    }
}
