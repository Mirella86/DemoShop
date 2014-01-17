using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.Model
{
	public class Cosmetic : Product
	{
		[DefaultValue("Clothes")]
		public string TypeOfProduct;
		public DateTime? FabricationDate { get; set; }
        public DateTime? ExpireDate { get; set; }

		public virtual ICollection<CosmeticSubCategories> ProductSubCategories { get; set; }
	}
}
