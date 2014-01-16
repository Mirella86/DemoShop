using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopDAL;
using ShopDomainServices;
using ShopModelMapper;

namespace WebApplicationService.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post(ClothingModel clothing)
        {
         //   IDomainServiceBase<Clothing> clothingService = DependencyFactory.Instance.GetDomainServiceBase();
         //   IDomainServiceBase<Clothing> clothingService = _container.Resolve<IDomainServiceBase<Clothing>>();
            //clothingService.Insert(new ClothingModel { Name = "Lee Cooper jeans blabla", Size = "34" });

            //IEnumerable<IModel> clothingModels = clothingService.GetAll();

            //foreach (var clothing in clothingModels)
            //{
            //    Console.WriteLine("{0}: {1}", ((ClothingModel)clothing).Name, ((ClothingModel)clothing).Size);
            //}
            //Console.WriteLine();

            //var cloth = clothingModels.ElementAt(1);
            //Console.WriteLine("Deleting element: {0}", ((ClothingModel)cloth).Name);
            //clothingService.Delete(clothingModels.ElementAt(1));
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}