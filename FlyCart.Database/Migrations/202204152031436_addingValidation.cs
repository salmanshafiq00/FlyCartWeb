namespace FlyCart.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Catagories", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Catagories", "Description", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Catagories", "Description", c => c.String());
            AlterColumn("dbo.Catagories", "Name", c => c.String());
        }
    }
}
