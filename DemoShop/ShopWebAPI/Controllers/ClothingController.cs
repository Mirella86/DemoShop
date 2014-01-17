using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ShopDomainServices;
using ShopModelMapper;

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
        public IEnumerable<ClothingModel> GetAllCosmetics()
        {

            return _clothingDomainService.GetAll().Cast<ClothingModel>().ToList();
        }
        // GET /Clothing/id
        public ClothingModel GetById(int id)
        {
            return (ClothingModel)_clothingDomainService.Get(id);
        }


        // POST Clothing
        public void Insert(ClothingModel model)
        {
            _clothingDomainService.Insert(model);
        }

        // PUT Clothing/5
        public void Update(int id, ClothingModel model)
        {
            _clothingDomainService.Update(model);
        }

        // DELETE Clothing/5
        public void Delete(int id)
        {
            _clothingDomainService.Delete(id);
        }
    }
}
