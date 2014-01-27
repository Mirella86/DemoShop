using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using ShopModels;

namespace ShopModelMapper
{
    public class CosmeticCategoryMapper : IMapper<Cosmetic_Category>
    {

        public Model GetModelFromEntity(Cosmetic_Category entity)
        {
            return new CosmeticCategoryModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Cosmetic_Category GetEntityFromModel(Model model)
        {
            var brandModel = (CosmeticCategoryModel)model;
            return new Cosmetic_Category()
            {
                Id = brandModel.Id,
                Name = brandModel.Name
            };
        }

        public Cosmetic_Category GetEntityFromModelKey(int key)
        {
            return new Cosmetic_Category
            {
                Id = key
            };
        }
    }
}
