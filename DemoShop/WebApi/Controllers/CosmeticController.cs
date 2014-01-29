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
        private IDomainService _cosmeticDomainService;

        public CosmeticController()
        {
            _cosmeticDomainService = WindsorResolver.Instance.GetInstanceOfDomainService(new CosmeticModel());
        }

        public IEnumerable<CosmeticModel> GetAll()
        {
            return _cosmeticDomainService.GetAll().Cast<CosmeticModel>().ToList();
        }


        public CosmeticModel Get(int id)
        {
            return (CosmeticModel)_cosmeticDomainService.Get(id);
        }

        public void InsertOrUpdate(CosmeticModel model)
        {
            if (model.Id == null || model.Id == 0)
                _cosmeticDomainService.Insert(model);
            else
                _cosmeticDomainService.Update(model);
        }

        public void Delete(int id)
        {
            _cosmeticDomainService.Delete(id);
        }


  
    }
}
