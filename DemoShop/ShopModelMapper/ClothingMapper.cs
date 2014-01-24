using System.Collections.Generic;
using System.Linq;
using DBEntities;
using ShopModels;


namespace ShopModelMapper
{
    public class ClothingMapper : IMapper<Clothing>
    {
        public Model GetModelFromEntity(Clothing entity)
        {

            IEnumerable<StockModel> stocks = entity.Clothing_Stock.Select(i => new StockModel { Id = i.Id, ClothingId = i.ClothingId, Size = i.Size, Stock = i.Stock }).Distinct().ToList();

            return new ClothingModel
            {
                Id = entity.Id,
                Name = entity.Name,
                BrandId = entity.BrandId,
                BrandName = entity.Clothing_Brand == null ? "" : entity.Clothing_Brand.Name,
                GenderId = entity.GenderId,
                GenderName = entity.Clothing_Gender == null ? "" : entity.Clothing_Gender.Name,
                CategoryId = entity.CategoryId,
                CategoryName = entity.Clothing_Category == null ? "" : entity.Clothing_Category.Name,
                Stocks = stocks

            };
        }

        public Clothing GetEntityFromModel(Model model)
        {
            var clothingModel = (ClothingModel)model;

            return new Clothing
            {
                Id = clothingModel.Id,
                Name = clothingModel.Name,
                BrandId = clothingModel.BrandId,
                CategoryId = clothingModel.CategoryId,
                GenderId = clothingModel.GenderId
          //      Clothing_Stock = (ICollection<Clothing_Stock>)GetStocksForClothing(clothingModel.Stocks, model.Id)
            };
        }

        //public IEnumerable<Clothing_Stock> GetStocksForClothing(IEnumerable<StockModel> stockModels, int Id)
        //{
        //    return stockModels.Select(model => new Clothing_Stock
        //    {
        //        Id = model.Id,
        //        ClothingId = Id,
        //        Size = model.Size,
        //        Stock = model.Stock
        //    });
        //}

        public Clothing GetEntityFromModelKey(int id)
        {
            return new Clothing
            {
                Id = id,
                Name = ""

            };
        }
    }
}
