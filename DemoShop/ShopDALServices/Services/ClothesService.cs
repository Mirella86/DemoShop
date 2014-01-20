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
	public class ClothesService : Service<Clothes>
	{
		public ClothesService(IRepository<Clothes> baseRepository, IUnitOfWork unitOfWork) : base(baseRepository, unitOfWork) { }
		
	}
}
