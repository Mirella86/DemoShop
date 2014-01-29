using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopDomainServices;
using ShopModelMapper;
using ShopModels;

namespace ShopDALTest
{
    [TestClass]

    public class ClothingDomainServiceTest
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

        }

        [TestMethod]
        public void VerifyModelIsTypeofClothingModel()
        {
            var clothing = _service.Get(1);
            Assert.IsInstanceOfType(clothing, typeof(ClothingModel));
        }

        [TestMethod]
        public void VerifyModelMapping()
        {
            var clothing = _service.Get(1);
            var clothingModel = (ClothingModel)clothing;

            Assert.AreEqual(clothingModel.Id, 1);
            Assert.AreEqual(clothingModel.Name, "Test");
            Assert.AreEqual(clothingModel.BrandId, 11);
            Assert.AreEqual(clothingModel.CategoryId, 22);
            Assert.AreEqual(clothingModel.GenderId, 33);
            Assert.AreEqual(clothingModel.CategoryName, "testCategory");
            Assert.AreEqual(clothingModel.BrandName, "testBrand");
            Assert.AreEqual(clothingModel.GenderName, "testGender");
        }

        [TestMethod]
        public void VerifyClothingStock()
        {
            var clothing = _service.Get(1);
            var clothingModel = (ClothingModel)clothing;

            Assert.IsNotNull(clothingModel.Stocks);
            Assert.AreEqual(clothingModel.Stocks.Count(), 3);
            Assert.AreEqual(clothingModel.Stocks.ElementAt(0).Id, 100);
            Assert.AreEqual(clothingModel.Stocks.ElementAt(0).Size, "100");
            Assert.AreEqual(clothingModel.Stocks.ElementAt(0).Stock, 100);
        }
    }
}
