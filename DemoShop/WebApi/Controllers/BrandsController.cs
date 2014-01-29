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
    public class BrandsController : ApiController
    {
        private IDomainService _domainService;

        [System.Web.Http.HttpGet]
        public IEnumerable<BrandModel> GetBrands(int productType)
        {
            switch (productType)
            {
                case 1:
                    _domainService = WindsorResolver.Instance.GetInstanceOfDomainService(new ClothingBrandModel());
                    return _domainService.GetAll().Cast<ClothingBrandModel>().ToList();
                case 2:
                    _domainService = WindsorResolver.Instance.GetInstanceOfDomainService(new CosmeticBrandModel());
                    return _domainService.GetAll().Cast<CosmeticBrandModel>().ToList();
                default:
                    throw new Exception("Cannot find brands");
            }
        }
    }
}
