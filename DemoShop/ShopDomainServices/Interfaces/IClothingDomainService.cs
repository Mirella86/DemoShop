using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using ShopDAL;
using ShopDomainServices;

namespace ShopDomainServices
{
    public interface IClothingDomainService : IDomainService<Clothing>
    {
    }
}
