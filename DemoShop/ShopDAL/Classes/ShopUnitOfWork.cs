using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ShopDAL
{
    public class ShopUnitOfWork : UnitOfWork, IDisposable
    {
        public ShopUnitOfWork()
        {
            dbContext = new DemoShopEntities();
        }

        public override void SaveChanges()
        {
            using (var transaction = new TransactionScope())
            {
                dbContext.SaveChanges();
                transaction.Complete();
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                    dbContext = null;
                }
            }
        }
    }


}
