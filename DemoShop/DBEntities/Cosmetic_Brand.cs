//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cosmetic_Brand
    {
        public Cosmetic_Brand()
        {
            this.Cosmetics = new HashSet<Cosmetic>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Cosmetic> Cosmetics { get; set; }
    }
}
