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
    public class CategoriesController : ApiController
    {

        private IClothingCategoryDomainService _clothingCategoryDomainService;
        private ICosmeticCategoryDomainService _cosmeticCategoryDomainService;


        [System.Web.Http.HttpGet]
        public IEnumerable<CategoryModel> GetBrands(int productType)
        {
            switch (productType)
            {
                case 1:
                    _clothingCategoryDomainService = WindsorResolver.Instance.ClothingCategoryDomainService;
                    return _clothingCategoryDomainService.GetAll().Cast<ClothingCategoryModel>().ToList();
                case 2:
                    _cosmeticCategoryDomainService = WindsorResolver.Instance.CosmeticCategoryDomainService;
                    return _cosmeticCategoryDomainService.GetAll().Cast<CosmeticCategoryModel>().ToList();
                default:
                    throw new Exception("Cannot find brands");
            }
        }
 
    }
}
