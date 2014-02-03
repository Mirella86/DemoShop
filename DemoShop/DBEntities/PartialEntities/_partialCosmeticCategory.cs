using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntities
{
    public partial class Cosmetic_Category:Entity
    {
        public override bool CompareTo(IEntity cosmetic_Category)
        {
            return this.Id == ((Cosmetic_Category)cosmetic_Category).Id;
        }
    }
}
