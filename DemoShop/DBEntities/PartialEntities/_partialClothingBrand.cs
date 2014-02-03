using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntities
{
    public partial class Clothing_Brand : Entity
    {
        public override bool CompareTo(IEntity clothingBrand)
        {
            return this.Id == ((Clothing_Brand)clothingBrand).Id;
        }
    }
}
