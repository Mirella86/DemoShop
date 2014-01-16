using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL;

namespace ShopModelMapper
{
    public class ClothingMapper : IMapper<Clothing>
    {
        public IModel GetModelFromEntity(Clothing entity)
        {
            return new ClothingModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Size = entity.Size
            };
        }

        public Clothing GetEntityFromModel(IModel model)
        {
            var clothingModel = (ClothingModel)model;
            return new Clothing
            {
                Id = clothingModel.Id,
                Name = clothingModel.Name,
                Size = clothingModel.Size

            };
        }
    }
}
