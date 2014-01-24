using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopDALServices;
using ShopModels;
using WebApplicationService;

namespace ShopUI.Controllers
{
    public class ClothingController : Controller
    {
        //private IClothingBrandDomainService _clothingBrandDomainService;
        //private ICosmeticBrandDomainService _cosmeticBrandDomainService;

        //
        // GET: /Cothing/

        public ActionResult Index()
        {
            return View();
        }


        //public IEnumerable<BrandModel> GetBrands(int productType)
        //{
        //    switch (productType)
        //    {
        //        case 1:
        //            _clothingBrandDomainService = WindsorResolver.Instance.ClothingBrandDomainService;
        //            return _clothingBrandDomainService.GetAll().Cast<ClothingBrandModel>().ToList();
        //        case 2:
        //            _cosmeticBrandDomainService = WindsorResolver.Instance.CosmeticBrandDomainService;
        //            return _cosmeticBrandDomainService.GetAll().Cast<CosmeticBrandModel>().ToList();
        //        default:
        //            throw new Exception("Cannot find brands");
        //    }



        //}
    }
}
