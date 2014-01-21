using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopDTO
{
	public class ClothesDTO : ProductDTO
	{
		public int TypeId { get; set; }
		public string Colection { get; set; }
	}
}
