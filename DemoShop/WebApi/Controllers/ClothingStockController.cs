using System.Web.Http;
using ShopDALServices;
using ShopDomainServices;
using ShopModels;
using WebApplicationService;

namespace WebApi.Controllers
{
    public class ClothingStockController : ApiController
    {
        private IDomainService _clothingStockDomainService;

        public ClothingStockController()
        {
            _clothingStockDomainService = WindsorResolver.Instance.GetInstanceOfDomainService(new StockModel());
        }

        public void InsertOrUpdate(StockModel model)
        {
            if (model.Id == null || model.Id == 0)
                _clothingStockDomainService.Insert(model);
            else
                _clothingStockDomainService.Update(model);
        }


        public void Delete(int Id)
        {
            _clothingStockDomainService.Delete(Id);
        }
    }
}
