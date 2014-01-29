using DBEntities;
using ShopDAL;
using ShopModelMapper;


namespace ShopDomainServices
{
    public class CosmeticDomainService : DomainService<Cosmetic>, ICosmeticDomainService
    {
        public CosmeticDomainService(IRepository<Cosmetic> repository, IMapper<Cosmetic> mapper) : base(repository, mapper)
        {
        }
    }
}
