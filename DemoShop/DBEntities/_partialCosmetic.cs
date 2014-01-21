using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntities
{
    public partial class Cosmetic : Entity
    {
        public override bool CompareTo(Entity cosmetic)
        {
            return (this.Id == ((Cosmetic)cosmetic).Id);
        }
    }
}
