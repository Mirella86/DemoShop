using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL.Model;
using ShopDAL.Repository;
using ShopDALRepository.Interfaces;

namespace ShopDALRepository.Repositories
{
	public partial class CosmeticRepository : Repository<Cosmetic>, ICosmeticRepository
	{
		#region Ctors

		public CosmeticRepository(string connectionString)
			: base(connectionString)
		{
		}
		public string GetName(object id)
		{
			Cosmetic entity = base.GetById(id);
			return entity.Name;
		}
		public double GetPrice(object id)
		{
			Cosmetic entity = base.GetById(id);
			return entity.Price;
		}
		public DateTime? GetExpireDate(object id)
		{
			Cosmetic entity = base.GetById(id);
			return entity.ExpireDate;
		}
		public DateTime? GetFabricationDate(object id)
		{
			Cosmetic entity = base.GetById(id);
			return entity.FabricationDate;
		}
		#endregion Ctors
	}
}
