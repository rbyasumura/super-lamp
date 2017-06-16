namespace Advance.Framework.Contexts.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserRoles", newName: "RoleUsers");
            DropPrimaryKey("dbo.RoleUsers");
            AddPrimaryKey("dbo.RoleUsers", new[] { "Role_RoleId", "User_UserId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.RoleUsers");
            AddPrimaryKey("dbo.RoleUsers", new[] { "User_UserId", "Role_RoleId" });
            RenameTable(name: "dbo.RoleUsers", newName: "UserRoles");
        }
    }
}
