using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using ShopModels;

namespace ShopModelMapper
{
    public class StockMapper : IMapper<Clothing_Stock>
    {
        public Model GetModelFromEntity(Clothing_Stock entity)
        {
            return new StockModel()
            {
                Id = entity.Id,
                Size = entity.Size,
                ClothingId = entity.ClothingId,
                Stock = entity.Stock

            };
        }

        public Clothing_Stock GetEntityFromModel(Model model)
        {
            var brandModel = (StockModel)model;
            return new Clothing_Stock
            {
                Id = brandModel.Id,
                Size = brandModel.Size,
                ClothingId = brandModel.ClothingId,
                Stock = brandModel.Stock
            };
        }

        public Clothing_Stock GetEntityFromModelKey(int key)
        {
            return new Clothing_Stock
            {
                Id = key
            };
        }
    }
}
