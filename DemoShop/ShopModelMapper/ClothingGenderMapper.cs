using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using ShopModels;

namespace ShopModelMapper
{
    public class ClothingGenderMapper : IMapper<Clothing_Gender>
    {

        public Model GetModelFromEntity(Clothing_Gender entity)
        {
            return new GenderModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Clothing_Gender GetEntityFromModel(Model model)
        {
            var brandModel = (GenderModel)model;
            return new Clothing_Gender()
            {
                Id = brandModel.Id,
                Name = brandModel.Name
            };
        }

        public Clothing_Gender GetEntityFromModelKey(int key)
        {
            return new Clothing_Gender
            {
                Id = key
            };
        }
    }
}
