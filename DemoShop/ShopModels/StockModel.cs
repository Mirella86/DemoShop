using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModels
{
    public class StockModel : Model
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public int Stock { get; set; }
        public int ClothingId { get; set; }

    }
}
