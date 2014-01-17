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
    public class CosmeticDomainService : DomainService<Cosmetic>, ICosmeticDomainService
    {
        public CosmeticDomainService(IRepository<Cosmetic> repository, IMapper<Cosmetic> mapper) : base(repository, mapper)
        {
        }
    }
}
