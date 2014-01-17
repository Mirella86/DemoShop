using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.Model
{
	public class ClothesSubCategories : ProductSubCategory
	{
		public virtual Clothes Products { get; set; }
	}
}
