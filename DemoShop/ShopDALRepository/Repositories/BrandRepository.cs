﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL.Model;
using ShopDAL.Repository;
using ShopDALRepository.Interfaces;

namespace ShopDALRepository.Repositories
{
	public partial class BrandRepository : Repository<Brand>, IBrandRepository
	{
		#region Ctors

		public BrandRepository(ShopContext context)
			: base(context)
		{

		}

		#endregion Ctors
	}
}