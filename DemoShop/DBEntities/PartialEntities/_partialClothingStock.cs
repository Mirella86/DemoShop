using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntities
{
    public partial class Clothing_Stock : Entity
    {
        public override bool CompareTo(Entity clothing_stock)
        {
            return (this.Id == ((Clothing_Stock)clothing_stock).Id);
        }
    }
}
