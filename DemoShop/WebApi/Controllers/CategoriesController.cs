using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopModels;

namespace WebApi.Controllers
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
    //    // GET api/categories
    //    public IEnumerable<string> Get()
    //    {
    //        return new string[] { "value1", "value2" };
    //    }

    //    // GET api/categories/5
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST api/categories
    //    public void Post([FromBody]string value)
    //    {
    //    }

    //    // PUT api/categories/5
    //    public void Put(int id, [FromBody]string value)
    //    {
    //    }

    //    // DELETE api/categories/5
    //    public void Delete(int id)
    //    {
    //    }
    }
}
