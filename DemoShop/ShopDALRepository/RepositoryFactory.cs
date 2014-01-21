using ShopDALRepository.Interfaces;
using ShopDALRepository.Repositories;
using ShopHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShopDALRepository
{
    public class RepositoryFactory
    {
        private readonly RepositoryFactory rpf;

        private IBrandRepository brandRepository;
        private ICosmeticRepository cosmeticRepository;
        private IClothesRepository clothesRepository;

        public RepositoryFactory(bool boolParameter) { }
        public RepositoryFactory()
        {
            rpf = HttpContext.Current.Items[ConfigurationHelper.HttpContextKey] as RepositoryFactory;

            if (rpf == null)
            {
                rpf = new RepositoryFactory(false);
                SaveToHttpContext();
            }
        }

        public IBrandRepository BrandRepository
        {
            get
            {
                if (rpf.brandRepository == null)
                {
                    rpf.brandRepository = new BrandRepository(ConfigurationHelper.ConnectionString);
                    SaveToHttpContext();
                }
                return rpf.brandRepository;
            }
        }

        public IClothesRepository ClothesRepository
        {
            get
            {
                if (rpf.clothesRepository == null)
                {
                    rpf.clothesRepository = new ClothesRepository(ConfigurationHelper.ConnectionString);
                    SaveToHttpContext();
                }
                return rpf.clothesRepository;
            }
        }
        public ICosmeticRepository CosmeticRepository
        {
            get
            {
                if (rpf.cosmeticRepository == null)
                {
                    rpf.cosmeticRepository = new CosmeticRepository(ConfigurationHelper.ConnectionString);
                    SaveToHttpContext();
                }
                return rpf.cosmeticRepository;
            }
        }
      

        private void SaveToHttpContext()
        {
            HttpContext.Current.Items[ConfigurationHelper.HttpContextKey] = rpf;
        }


    }
}
