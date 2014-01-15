namespace ShopDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainCategoryId = c.Int(nullable: false),
                        SizeId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        DestinationId = c.Int(nullable: false),
                        ColourId = c.Int(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        FabricationDate = c.DateTime(),
                        ExpireDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductSubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Sequence = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Size",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Destination",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Colour",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductSubCategories", new[] { "ProductId" });
            DropForeignKey("dbo.ProductSubCategories", "ProductId", "dbo.Product");
            DropTable("dbo.Colour");
            DropTable("dbo.Destination");
            DropTable("dbo.Size");
            DropTable("dbo.Category");
            DropTable("dbo.Brand");
            DropTable("dbo.ProductSubCategories");
            DropTable("dbo.Product");
        }
    }
}
