using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ShopDomainServices;
using ShopModelMapper;
using ShopModels;

namespace WebApplicationService
{
    public class ClothingController : ApiController
    {
        private IClothingDomainService _clothingDomainService;
        // GET: /Cosmetic/


        public ClothingController()
        {
            _clothingDomainService = WindsorResolver.Instance.ClothingDomainService;
        }

        // GET /Clothing
        [HttpGet]
        [ActionName("GetAllClothings")]
        public IEnumerable<ClothingModel> GetAllClothing()
        {
            return _clothingDomainService.GetAll().Cast<ClothingModel>().ToList();
        }
      
        
        // GET /Clothing/id
        [ActionName("GetClothingById")]
        public ClothingModel GetById(int id)
        {
            return (ClothingModel)_clothingDomainService.Get(id);
        }


        // POST Clothing
        [ActionName("InsertOrUpdate")]
        public void InsertOrUpdate(ClothingModel model)
        {
            if (model.Id == null || model.Id == 0)
                _clothingDomainService.Insert(model);
            else
                _clothingDomainService.Update(model);
        }

        [HttpDelete]
        [ActionName("Delete")]
        public void Delete(int id)
        {
            _clothingDomainService.Delete(id);
        }




    }
}
