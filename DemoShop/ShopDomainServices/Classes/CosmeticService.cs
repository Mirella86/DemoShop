using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL;
using ShopModelMapper;


namespace ShopDomainServices
{
    public class CosmeticService : DomainServiceBase<Cosmetic>, ICosmeticService
    {
        public CosmeticService(IRepository<Cosmetic> repository, IMapper<Cosmetic> mapper) : base(repository, mapper)
        {
        }
    }
}
