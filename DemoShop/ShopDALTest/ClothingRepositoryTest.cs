using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopDomainServices;
using ShopModelMapper;
using ShopModels;

namespace ShopDALTest
{
    [TestClass]

    public class ClothingRepositoryTest
    {
        private ClothingRepositoryFake _repository;
        private ClothingMapper _mapper;
        private ClothingDomainService _service;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new ClothingRepositoryFake();
            _mapper = new ClothingMapper();
            _service = new ClothingDomainService(_repository, _mapper);
        }

        [TestMethod]
        public void VerifyGetClothingSuccess()
        {
            var clothing = _service.Get(1);



            Assert.IsNotNull(clothing);
            Assert.IsInstanceOfType(clothing, typeof(ClothingModel));

            ClothingModel clothingModel = (ClothingModel)clothing;
            Assert.AreEqual(clothingModel.CategoryName, "testCategory");
            Assert.AreEqual(clothingModel.BrandName, "testBrand");
            Assert.AreEqual(clothingModel.GenderName, "testGender");

       }

    }
}
