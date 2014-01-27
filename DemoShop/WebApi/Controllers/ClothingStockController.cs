using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopDALServices;
using ShopModels;
using WebApplicationService;

namespace WebApi.Controllers
{
    public class ClothingStockController : ApiController
    {
        private IClothingStockDomainService _clothingStockDomainService;

        public void InsertOrUpdate(StockModel model)
        {
            _clothingStockDomainService = WindsorResolver.Instance.ClothingStockDomainService;

            if (model.Id == null || model.Id == 0)
                _clothingStockDomainService.Insert(model);
            else
                _clothingStockDomainService.Update(model);
        }


        [HttpDelete]
        public void Delete(int Id)
        {
            _clothingStockDomainService.Delete(Id);
        }
    }
}
