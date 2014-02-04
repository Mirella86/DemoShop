using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using ShopDomainServices;
using ShopModels;
using WebApplicationService;

namespace WebApi.Controllers
{
    public class ClothingController : ApiController
    {
        private IDomainService _clothingDomainService;
        private readonly int PAGE_ITEMS_NO = 2;

        public ClothingController()
        {
            _clothingDomainService = WindsorResolver.Instance.GetInstanceOfDomainService(new ClothingModel());
        }

        public int GetTotalPages()
        {
            var noOfPages = _clothingDomainService.GetAll().Count() / PAGE_ITEMS_NO;

            if (_clothingDomainService.GetAll().Count() % PAGE_ITEMS_NO != 0)
                noOfPages += 1;

            return noOfPages;
        }

        // GET api/Clothing
        public IEnumerable<ClothingModel> GetAllClothing(int pageIndex)
        {
            IEnumerable<ClothingModel> allClothingModels = _clothingDomainService.GetAll().Cast<ClothingModel>().ToList();
            return allClothingModels.Skip(pageIndex * PAGE_ITEMS_NO).Take(PAGE_ITEMS_NO);
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
