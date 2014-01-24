using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopModels;

namespace WebApplicationService.Controllers
{
    public class CategoriesController : ApiController
    {

        public IEnumerable<CategoryModel> GetBrands()
        {
            var categories = new List<CategoryModel>
            {
                new CategoryModel {Id = 1, Name = "Blouses"},
                new CategoryModel {Id = 2, Name = "Pants"},
                new CategoryModel {Id = 3, Name = "Jackets"}
            };

            return categories;

        }
    }
}
