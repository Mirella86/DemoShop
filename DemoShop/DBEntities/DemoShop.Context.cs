﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DemoShopEntities : DbContext
    {
        public DemoShopEntities()
            : base("name=DemoShopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Clothing> Clothings { get; set; }
        public DbSet<Clothing_Brand> Clothing_Brand { get; set; }
        public DbSet<Clothing_Category> Clothing_Category { get; set; }
        public DbSet<Clothing_Gender> Clothing_Gender { get; set; }
        public DbSet<Clothing_Stock> Clothing_Stock { get; set; }
        public DbSet<Cosmetic> Cosmetics { get; set; }
        public DbSet<Cosmetic_Brand> Cosmetic_Brand { get; set; }
        public DbSet<Cosmetic_Category> Cosmetic_Category { get; set; }
    }
}
