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
    class ClothingCategoryDomainService :DomainService<Clothing_Category>, IClothingCategoryDomainService
    {
        public ClothingCategoryDomainService(IRepository<Clothing_Category> repository, IMapper<Clothing_Category> mapper) : base(repository, mapper)
        {
        }
    }
}
