using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntities
{
    public partial class Clothing_Gender : Entity
    {
        public override bool CompareTo(IEntity clothing_Gender)
        {
            return this.Id == ((Cosmetic_Brand)clothing_Gender).Id;
        }
    }
}
