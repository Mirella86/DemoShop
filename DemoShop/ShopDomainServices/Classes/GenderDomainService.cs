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
    public class GenderDomainService : DomainService<Clothing_Gender>, IGenderDomainService
    {
        public GenderDomainService(IRepository<Clothing_Gender> repository, IMapper<Clothing_Gender> mapper)
            : base(repository, mapper)
        {
        }
    }
}
