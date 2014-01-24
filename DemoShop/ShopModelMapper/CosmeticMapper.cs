using DBEntities;
using ShopModels;


namespace ShopModelMapper
{
    public class CosmeticMapper : IMapper<Cosmetic>
    {
        public string Name { get; set; }


        public Model GetModelFromEntity(Cosmetic entity)
        {

            return new CosmeticModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Stock = entity.Stock,
                BrandId = entity.BrandId,
                BrandName = entity.Cosmetic_Brand == null ? "" : entity.Cosmetic_Brand.Name,
                CategoryId = entity.CategoryId,
                CategoryName = entity.Cosmetic_Category == null ? "" : entity.Cosmetic_Category.Name

            };
        }

        public Cosmetic GetEntityFromModel(Model model)
        {
            var cosmeticModel = (CosmeticModel)model;
            return new Cosmetic
            {
                Id = cosmeticModel.Id,
                Name = cosmeticModel.Name,
                BrandId=cosmeticModel.BrandId,
                CategoryId=cosmeticModel.CategoryId,
                Stock=cosmeticModel.Stock
            };
        }

        public Cosmetic GetEntityFromModelKey(int id)
        {
            return new Cosmetic
            {
                Id = id,
                Name = ""
            };
        }
    }
}
