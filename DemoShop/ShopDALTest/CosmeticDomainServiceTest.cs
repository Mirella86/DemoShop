using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopDALTest.Fakes;
using ShopDomainServices;
using ShopModelMapper;
using ShopModels;

namespace ShopDALTest
{
    [TestClass]
    public class CosmeticDomainServiceTest
    {
        private CosmeticRepositoryFake _repository;
        private CosmeticMapper _mapper;
        private CosmeticDomainService _service;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new CosmeticRepositoryFake();
            _mapper = new CosmeticMapper();
            _service = new CosmeticDomainService(_repository, _mapper);
        }

        [TestMethod]
        public void VerifyGetCosmeticSuccess()
        {
            var cosmetic = _service.Get(1);

            Assert.IsNotNull(cosmetic);
            Assert.IsInstanceOfType(cosmetic, typeof(CosmeticModel));

        }

        [TestMethod]
        public void VerifyModelIsTypeofCosmeticModel()
        {
            var cosmetic = _service.Get(1);
            Assert.IsInstanceOfType(cosmetic, typeof(CosmeticModel));
        }

        [TestMethod]
        public void VerifyModelMapping()
        {
            var cosmetic = _service.Get(1);
            var cosmeticModel = (CosmeticModel)cosmetic;

            Assert.AreEqual(cosmeticModel.Id, 1);
            Assert.AreEqual(cosmeticModel.Name, "product1");
            Assert.AreEqual(cosmeticModel.BrandId, 11);
            Assert.AreEqual(cosmeticModel.CategoryId,111);
        }


    }
}
