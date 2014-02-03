using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntities
{
    public partial class Cosmetic_Brand : Entity
    {
        public override bool CompareTo(IEntity cosmeticBrand)
        {
            return this.Id == ((Cosmetic_Brand)cosmeticBrand).Id;
        }
    }
}
