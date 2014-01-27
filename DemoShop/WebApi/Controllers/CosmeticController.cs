using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBEntities;
using ShopDomainServices;
using ShopModels;
using WebApplicationService;

namespace WebApi.Controllers
{
    public class CosmeticController : ApiController
    {
        private ICosmeticDomainService _cosmeticDomainService;
        // GET /cosmetic

        public CosmeticController()
        {
            _cosmeticDomainService = WindsorResolver.Instance.CosmeticDomainService;
        }

        public IEnumerable<CosmeticModel> GetAll()
        {
            return _cosmeticDomainService.GetAll().Cast<CosmeticModel>().ToList();
        }

        // GET cosmetic/5
        public CosmeticModel Get(int id)
        {
            return (CosmeticModel)_cosmeticDomainService.Get(id);
        }

        // POST cosmetic
        //[ActionName("InsertOrUpdate")]
        public void InsertOrUpdate(CosmeticModel model)
        {
            if (model.Id == null || model.Id == 0)
                _cosmeticDomainService.Insert(model);
            else
                _cosmeticDomainService.Update(model);
        }

        // DELETE cosmetic/5
        //[HttpDelete]
        //[ActionName("Delete")]
        public void Delete(int id)
        {
            _cosmeticDomainService.Delete(id);
        }

        //// GET api/cosmetic
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/cosmetic/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/cosmetic
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/cosmetic/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/cosmetic/5
        //public void Delete(int id)
        //{
        //}
    }
}
