using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopDomainServices;
using ShopModels;
using WebApplicationService;

namespace WebApi.Controllers
{
    public class ClothingController : ApiController
    {
        private IDomainService _clothingDomainService;

        public ClothingController()
        {
            _clothingDomainService = WindsorResolver.Instance.GetInstanceOfDomainService(new ClothingModel());
        }

        // GET api/Clothing
        public IEnumerable<ClothingModel> GetAllClothing()
        {
            return _clothingDomainService.GetAll().Cast<ClothingModel>().ToList();
        }

        public void InsertOrUpdate(ClothingModel model)
        {
            if (model.Id == null || model.Id == 0)
                _clothingDomainService.Insert(model);
            else
                _clothingDomainService.Update(model);
        }

        public void Delete(int id)
        {
            _clothingDomainService.Delete(id);
        }

    }
}
