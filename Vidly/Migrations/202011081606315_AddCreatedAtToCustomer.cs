namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedAtToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Customers", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Customers", "CreatedBy", c => c.String());
            AddColumn("dbo.Customers", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ModifiedBy");
            DropColumn("dbo.Customers", "CreatedBy");
            DropColumn("dbo.Customers", "ModifiedDate");
            DropColumn("dbo.Customers", "CreatedDate");
        }
    }
}
