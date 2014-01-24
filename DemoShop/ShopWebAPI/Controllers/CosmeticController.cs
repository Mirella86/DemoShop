using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopDomainServices;
using ShopModelMapper;
using ShopModels;

namespace WebApplicationService.Controllers
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
        [ActionName("InsertOrUpdate")]
        public void InsertOrUpdate(ClothingModel model)
        {
            if (model.Id == null || model.Id == 0)
                _cosmeticDomainService.Insert(model);
            else
                _cosmeticDomainService.Update(model);
        }

        // DELETE cosmetic/5
        [HttpDelete]
        [ActionName("Delete")]
        public void Delete(int id)
        {
            _cosmeticDomainService.Delete(id);
        }
    }
}
