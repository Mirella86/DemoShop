using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL
{
    public class ClothingRepository : RepositoryBase<Clothing>, IClothingRepository
    {
        public ClothingRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
