using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using ShopDomainServices;
using ShopModels;

namespace ShopDALServices
{
    public interface IGenderDomainService :IDomainService<Clothing_Gender>
    {
    }
}
