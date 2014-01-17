using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopDomainServices;
using ShopModelMapper;

namespace WebApplicationService.Controllers
{
    public class CosmeticController : ApiController
    {
        private ICosmeticDomainService _cosmeticDomainService;
        // GET /cosmetic
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
        public void Insert(CosmeticModel model)
        {
            _cosmeticDomainService.Insert(model);
        }

        // PUT cosmetic/5
        public void Update(int id, CosmeticModel model)
        {
            _cosmeticDomainService.Update(model);
        }

        // DELETE cosmetic/5
        public void Delete(int id)
        {
            _cosmeticDomainService.Delete(id);
        }
    }
}
