using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL.Model;
using ShopDALRepository.Interfaces;
using ShopDALServices.Interfaces;

namespace ShopDALServices.Services
{
	public class CosmeticService : Service<Cosmetic>
	{
		public CosmeticService(IRepository<Cosmetic> baseRepository, IUnitOfWork unitOfWork) : base(baseRepository, unitOfWork) { }
        public CosmeticService(IRepository<Cosmetic> baseRepository) : base(baseRepository) { }
      
	}
}
