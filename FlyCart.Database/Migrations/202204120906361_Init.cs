namespace FlyCart.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        CatagoryID = c.Int(nullable: false),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Images = c.String(),
                        Stock = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Catagories", t => t.CatagoryID, cascadeDelete: true)
                .Index(t => t.CatagoryID);
            
            CreateTable(
                "dbo.ProductOptions",
                c => new
                    {
                        ProductOptionID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        OptionGroupID = c.Int(nullable: false),
                        Option_OptionID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductOptionID)
                .ForeignKey("dbo.Options", t => t.Option_OptionID)
                .ForeignKey("dbo.OptionGroups", t => t.OptionGroupID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.OptionGroupID)
                .Index(t => t.Option_OptionID);
            
            CreateTable(
                "dbo.OptionGroups",
                c => new
                    {
                        OptionGroupID = c.Int(nullable: false, identity: true),
                        OptionGroupName = c.String(),
                    })
                .PrimaryKey(t => t.OptionGroupID);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        OptionID = c.Int(nullable: false, identity: true),
                        OptionGroupID = c.Int(nullable: false),
                        OptionName = c.String(),
                    })
                .PrimaryKey(t => t.OptionID)
                .ForeignKey("dbo.OptionGroups", t => t.OptionGroupID, cascadeDelete: true)
                .Index(t => t.OptionGroupID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Billing_Address = c.String(),
                        Shippig_Address = c.String(),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOptions", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductOptions", "OptionGroupID", "dbo.OptionGroups");
            DropForeignKey("dbo.ProductOptions", "Option_OptionID", "dbo.Options");
            DropForeignKey("dbo.Options", "OptionGroupID", "dbo.OptionGroups");
            DropForeignKey("dbo.Products", "CatagoryID", "dbo.Catagories");
            DropIndex("dbo.Options", new[] { "OptionGroupID" });
            DropIndex("dbo.ProductOptions", new[] { "Option_OptionID" });
            DropIndex("dbo.ProductOptions", new[] { "OptionGroupID" });
            DropIndex("dbo.ProductOptions", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "CatagoryID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Options");
            DropTable("dbo.OptionGroups");
            DropTable("dbo.ProductOptions");
            DropTable("dbo.Products");
            DropTable("dbo.Catagories");
        }
    }
}
