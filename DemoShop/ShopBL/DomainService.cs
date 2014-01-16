using System.Collections.Generic;
using Castle.Windsor;
using ShopDAL;
using ShopDALServices;
using ShopModelMapper;

namespace ShopBL
{
    public class DomainService<TModel> : IDomainService<TModel> where TModel : class
    {
        private IDALServiceBase<Clothing> _clothingServiceBase;
        private IDALServiceBase<Cosmetic> _cosmeticServiceBase; 

        public DomainService(IModel model, WindsorContainer container)
        {
            if (model.GetType() == (typeof (ClothingModel)))
                _clothingServiceBase = container.Resolve<IDALServiceBase<Clothing>>();

            if (model.GetType() == (typeof(CosmeticModel)))
                _cosmeticServiceBase = container.Resolve<IDALServiceBase<Cosmetic>>();
        }

        public IEnumerable<IModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(IModel entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(IModel entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(IModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}