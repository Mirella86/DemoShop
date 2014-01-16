using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL
{
    public abstract class UnitOfWork
    {
        public DbContext dbContext { get; protected set; }
        public abstract void SaveChanges();
    }
}
