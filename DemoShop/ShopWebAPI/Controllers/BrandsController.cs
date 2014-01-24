using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopModels;

namespace WebApplicationService.Controllers
{
    public class BrandsController : ApiController
    {

        public IEnumerable<BrandModel> GetBrands()
        {

            var brands = new List<BrandModel>
            {
                new BrandModel {Id = 1, Name = "H&M"},
                new BrandModel {Id = 2, Name = "Zara"},
                new BrandModel {Id = 3, Name = "New Look"}
            };

            return brands;

        }

    }

}
