using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopModels;

namespace WebApplicationService.Controllers
{
    public class GenderController : ApiController
    {
        ////constants related controllers
        [ActionName("GetGenders")]
        public IEnumerable<GenderModel> GetGenders()
        {
            var genders = new List<GenderModel>
            {
                new GenderModel {Id = 1, Name = "Men"},
                new GenderModel {Id = 2, Name = "Women"},
                new GenderModel {Id = 3, Name = "Children"}
            };

            return genders;

        }
    }
}
