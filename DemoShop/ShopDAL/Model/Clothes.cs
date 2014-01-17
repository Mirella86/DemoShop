using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.Model
{
	public class Clothes : Product
	{
		[DefaultValue("Clothes")]
		public string TypeOfProduct;
		public string Colection;

		public virtual ICollection<ClothesSubCategories> ProductSubCategories { get; set; }
	}
}
