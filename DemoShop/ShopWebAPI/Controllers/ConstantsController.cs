using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopModels;

namespace WebApplicationService.Controllers
{
    public class ConstantsController : ApiController
    {

        public IEnumerable<BrandModel> GetConstants()
        {

            var brands = new List<BrandModel>();

            brands.Add(new BrandModel { Id = 1, Name = "H&M" });
            brands.Add(new BrandModel { Id = 2, Name = "Zara" });
            brands.Add(new BrandModel { Id = 3, Name = "New Look" });

            return brands;

        }

    }

}
