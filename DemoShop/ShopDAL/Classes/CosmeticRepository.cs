using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL
{
    public class CosmeticRepository : RepositoryBase<Cosmetic>, ICosmeticRepository
    {
        public CosmeticRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
