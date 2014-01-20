﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopDAL.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
	using System.Data.Entity.ModelConfiguration.Conventions;
    
    public partial class ShopContext : DbContext
    {
		public ShopContext()
        {
        }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

		public DbSet<Clothes> Clothes { get; set; }
        public DbSet<Cosmetic> Cosmetic { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Destination> Destinations { get; set; }
	    public DbSet<Colour> Colours { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }
    }
}