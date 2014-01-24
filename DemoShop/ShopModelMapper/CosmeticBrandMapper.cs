using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using ShopModels;

namespace ShopModelMapper
{
    public class CosmeticBrandMapper : IMapper<Cosmetic_Brand>
    {
        public Model GetModelFromEntity(Cosmetic_Brand entity)
        {
            return new CosmeticBrandModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Cosmetic_Brand GetEntityFromModel(Model model)
        {
            var brandModel = (CosmeticBrandModel)model;
            return new Cosmetic_Brand
            {
                Id = brandModel.Id,
                Name = brandModel.Name
            };
        }

        public Cosmetic_Brand GetEntityFromModelKey(int key)
        {
            return new Cosmetic_Brand
            {
                Id = key
            };
        }
    }
}
