using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.Model
{
	public abstract class ProductSubCategory
	{
			public int Id { get; set; }
			public int ProductsId { get; set; }
			public int CategoryId { get; set; }
			public int Sequence { get; set; }
	}
}
