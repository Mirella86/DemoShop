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
    
    public partial class Cosmetic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int Stock { get; set; }
    
        public virtual Clothing_Brand Clothing_Brand { get; set; }
        public virtual Cosmetic_Category Cosmetic_Category { get; set; }
    }
}
