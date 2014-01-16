using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL;

namespace ShopModelMapper
{
    public class CosmeticMapper : IMapper<Cosmetic>
    {
        public string Name { get; set; }


        public IModel GetModelFromEntity(Cosmetic entity)
        {

            return new CosmeticModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Cosmetic GetEntityFromModel(IModel model)
        {
            var cosmeticModel = (CosmeticModel) model;
            return new Cosmetic
            {
                Id = cosmeticModel.Id,
                Name = cosmeticModel.Name
            };
        }
    }
}
