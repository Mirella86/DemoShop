using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;

namespace DBEntities
{
    public partial class Clothing_Category : Entity
    {
        public override bool CompareTo(IEntity clothingCategory)
        {
            return this.Id == ((Clothing_Category)clothingCategory).Id;
        }
    }
}
