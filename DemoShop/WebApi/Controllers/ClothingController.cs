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
      //  private IClothingDomainService _clothingDomainService;
        private IDomainService _clothingDomainService;

        public ClothingController()
        {
         //   _clothingDomainService = WindsorResolver.Instance.ClothingDomainService;
            _clothingDomainService = WindsorResolver.Instance.GetInstanceOfDomainService(new ClothingModel());
        }

        // GET api/Clothing
        public IEnumerable<ClothingModel> GetAllClothing()
        {
            return _clothingDomainService.GetAll().Cast<ClothingModel>().ToList();
        }

        //public ClothingModel GetById(int id)
        //{
        //    return (ClothingModel)_clothingDomainService.Get(id);
        //}

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

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
