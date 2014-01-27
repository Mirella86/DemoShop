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
    public class GendersController : ApiController
    {
        private IClothingBrandDomainService _clothingBrandDomainService;
        private ICosmeticBrandDomainService _cosmeticBrandDomainService;

        public GendersController()
        {

        }

        private IGenderDomainService _genderDomainService;

        [System.Web.Http.HttpGet]
        public IEnumerable<GenderModel> GetGenders()
        {
            _genderDomainService = WindsorResolver.Instance.GenderDomainService;
            return _genderDomainService.GetAll().Cast<GenderModel>().ToList();

        }


    }
}
