using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL;
using ShopModelMapper;

namespace ShopDALServices
{
    public class DALClothingService : DALServiceBase<Clothing>, IDALClothingService
    {
        public DALClothingService(IRepository<Clothing> repository, IMapper<Clothing> mapper) : base(repository, mapper)
        {
        }
    }
}
