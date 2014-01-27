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
    public class BrandsController : ApiController
    {
        private IClothingBrandDomainService _clothingBrandDomainService;
        private ICosmeticBrandDomainService _cosmeticBrandDomainService;


        [System.Web.Http.HttpGet]
        public IEnumerable<BrandModel> GetBrands(int productType)
        {
            switch (productType)
            {
                case 1:
                    _clothingBrandDomainService = WindsorResolver.Instance.ClothingBrandDomainService;
                    return _clothingBrandDomainService.GetAll().Cast<ClothingBrandModel>().ToList();
                case 2:
                    _cosmeticBrandDomainService = WindsorResolver.Instance.CosmeticBrandDomainService;
                    return _cosmeticBrandDomainService.GetAll().Cast<CosmeticBrandModel>().ToList();
                default:
                    throw new Exception("Cannot find brands");
            }
        }
    }
}
