using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopDALServices;
using ShopDomainServices;
using ShopModels;
using WebApplicationService;

namespace WebApi.Controllers
{
    public class CategoriesController : ApiController
    {

        private IDomainService _domainService;

        [System.Web.Http.HttpGet]
        public IEnumerable<CategoryModel> GetBrands(int productType)
        {
            switch (productType)
            {
                case 1:
                    _domainService = WindsorResolver.Instance.GetInstanceOfDomainService(new ClothingCategoryModel());
                    return _domainService.GetAll().Cast<ClothingCategoryModel>().ToList();
                case 2:
                    _domainService = WindsorResolver.Instance.GetInstanceOfDomainService(new CosmeticCategoryModel());
                    return _domainService.GetAll().Cast<CosmeticCategoryModel>().ToList();
                default:
                    throw new Exception("Cannot find brands");
            }
        }
 
    }
}
