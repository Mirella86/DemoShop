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
    public class GendersController : ApiController
    {
        public GendersController()
        {

        }

        private IDomainService _genderDomainService;

        [System.Web.Http.HttpGet]
        public IEnumerable<GenderModel> GetGenders()
        {
            _genderDomainService = WindsorResolver.Instance.GetInstanceOfDomainService(new GenderModel());
            return _genderDomainService.GetAll().Cast<GenderModel>().ToList();

        }


    }
}
