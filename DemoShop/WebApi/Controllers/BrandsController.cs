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

        public BrandsController()
        {

        }
        [System.Web.Mvc.AcceptVerbs("GET", "POST")]
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

        //// GET api/brands
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/brands/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/brands
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/brands/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/brands/5
        //public void Delete(int id)
        //{
        //}
    }
}
