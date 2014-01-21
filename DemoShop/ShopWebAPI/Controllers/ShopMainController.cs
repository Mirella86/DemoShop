using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationService.Controllers
{
    public class ShopMainController : ApiController
    {
        public IEnumerable<ProductType> GetProductTypes()
        {
            var productTypes = new List<ProductType>();

            foreach (var pte in Enum.GetValues(typeof(ShopMainController.ProductTypeEnum)))
            {
                productTypes.Add(new ProductType((int)pte, pte.ToString()));
            }
            return productTypes;
        }

        public enum ProductTypeEnum
        {
            Clothing = 1,
            Cosmetic = 2
        }



        // GET api/shopmain/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/shopmain
        public void Post([FromBody]string value)
        {
        }

        // PUT api/shopmain/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/shopmain/5
        public void Delete(int id)
        {
        }
    }

    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProductType()
        {
   
        }

        public ProductType(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
