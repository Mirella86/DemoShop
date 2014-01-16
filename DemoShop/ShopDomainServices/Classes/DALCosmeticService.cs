using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL;
using ShopModelMapper;


namespace ShopDALServices
{
    public class DALCosmeticService : DALServiceBase<Cosmetic>, IDALCosmeticService
    {
        public DALCosmeticService(IRepository<Cosmetic> repository, IMapper<Cosmetic> mapper) : base(repository, mapper)
        {
        }
    }
}
