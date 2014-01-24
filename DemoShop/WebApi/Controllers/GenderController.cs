using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopModels;

namespace WebApi.Controllers
{
    public class GenderController : ApiController
    {
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
        //// GET api/gender
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/gender/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/gender
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/gender/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/gender/5
        //public void Delete(int id)
        //{
        //}
    }
}
