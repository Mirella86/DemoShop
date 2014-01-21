using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModels
{
    public class ClothingModel : IModel
    {
        public string Name { get; set; }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public IEnumerable<StockModel> Stocks { get; set; }
    }
}
