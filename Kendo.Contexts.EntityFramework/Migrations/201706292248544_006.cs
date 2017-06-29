namespace Kendo.Contexts.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _006 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrants", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Registrants", "UpdatedAt", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registrants", "UpdatedAt");
            DropColumn("dbo.Registrants", "CreatedAt");
        }
    }
}
