namespace Advance.Framework.Contexts.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WebPages", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.WebPages", "UpdatedAt", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.WebPages", "VersionId", c => c.Guid(nullable: false));
            AddColumn("dbo.WebPages", "PreviousVersionId", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WebPages", "PreviousVersionId");
            DropColumn("dbo.WebPages", "VersionId");
            DropColumn("dbo.WebPages", "UpdatedAt");
            DropColumn("dbo.WebPages", "CreatedAt");
        }
    }
}
