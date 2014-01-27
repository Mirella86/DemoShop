using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using ShopDAL;
using ShopDomainServices;
using ShopModelMapper;

namespace ShopDALServices.Classes
{
    public class ClothingStockDomainService :DomainService<Clothing_Stock>, IClothingStockDomainService
    {
        public ClothingStockDomainService(IRepository<Clothing_Stock> repository, IMapper<Clothing_Stock> mapper) : base(repository, mapper)
        {
        }
    }
}
