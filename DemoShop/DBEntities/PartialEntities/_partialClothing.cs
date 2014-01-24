using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntities
{
    public partial class Clothing : Entity
    {

        public override bool CompareTo(Entity clothing)
        {
            return (this.Id == ((Clothing)clothing).Id);
        }
    }
}
