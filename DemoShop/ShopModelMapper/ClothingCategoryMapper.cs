using DBEntities;
using ShopModels;

namespace ShopModelMapper
{
    public class ClothingCategoryMapper : IMapper<Clothing_Category>
    {

        public Model GetModelFromEntity(Clothing_Category entity)
        {
            return new ClothingCategoryModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Clothing_Category GetEntityFromModel(Model model)
        {
            var brandModel = (ClothingCategoryModel)model;
            return new Clothing_Category()
            {
                Id = brandModel.Id,
                Name = brandModel.Name
            };
        }

        public Clothing_Category GetEntityFromModelKey(int key)
        {
            return new Clothing_Category
            {
                Id = key
            };
        }
    }
}
