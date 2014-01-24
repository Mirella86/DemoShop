using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using ShopModels;

namespace ShopModelMapper
{
    public class ClothingBrandMapper : IMapper<Clothing_Brand>
    {
        public Model GetModelFromEntity(Clothing_Brand entity)
        {
            return new ClothingBrandModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Clothing_Brand GetEntityFromModel(Model model)
        {
            var brandModel = (ClothingBrandModel)model;
            return new Clothing_Brand
            {
                Id = brandModel.Id,
                Name = brandModel.Name
            };
        }

        public Clothing_Brand GetEntityFromModelKey(int key)
        {
            return new Clothing_Brand
            {
                Id = key
            };
        }
    }
}
