using ShopDALRepository;
using ShopDALRepository.Interfaces;
using ShopDALRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShopDALServices.Services
{
    public class ServicesManager
    {
        private ClothesService clothesService;
        private CosmeticService cosmeticService;
        private BrandService brandService;
        

        public ClothesService ClothesService
        {
            get
            {
                if (clothesService != null) return clothesService;
                clothesService = new ClothesService(new RepositoryFactory().ClothesRepository);
                SaveToContext();
                return clothesService;
            }
        }
        public CosmeticService CosmeticService
        {
            get
            {
                if (cosmeticService != null) return cosmeticService;
                cosmeticService = new CosmeticService(new RepositoryFactory().CosmeticRepository);
                SaveToContext();
                return cosmeticService;
            }
        }
        public BrandService BrandService
        {
            get
            {
                if (brandService != null) return brandService;
                brandService = new BrandService(new RepositoryFactory().BrandRepository);
                SaveToContext();
                return brandService;
            }
        }
       

        // nested class used for lazy initialization
        private class FactoryCreator
        {
            internal const string HTTPCONTEXTKEY = "ShopFactory";
            private static ServicesManager _uniqueInstance;
            private static object _syncRoot = new object();

            internal static ServicesManager UniqueInstance
            {
                get
                {
                    _uniqueInstance = HttpContext.Current.Items[HTTPCONTEXTKEY] as ServicesManager;
                    if (_uniqueInstance != null) return _uniqueInstance;
                    lock (_syncRoot)
                    {
                        _uniqueInstance = new ServicesManager();
                        HttpContext.Current.Items.Add(HTTPCONTEXTKEY, _uniqueInstance);
                    }
                    return _uniqueInstance;
                }
            }

            internal static void UpdateInstance(ServicesManager updatedFactory)
            {
                HttpContext.Current.Items[HTTPCONTEXTKEY] = updatedFactory;
            }
        }

        public static ServicesManager Instance
        {
            get { return FactoryCreator.UniqueInstance; }
        }

        private void SaveToContext()
        {
            FactoryCreator.UpdateInstance(this);
        }
    }
}
