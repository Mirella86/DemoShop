using ShopDAL.Model;
using ShopDAL.Repository;
using ShopDALRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDALRepository.Repositories
{
    public class ColourRepository : Repository<Colour>, IColourRepository
	{
        #region Ctors

		public ColourRepository(string connectionString)
            : base(connectionString)
		{

		}

		#endregion Ctors
	}
}
