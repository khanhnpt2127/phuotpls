namespace PhuotApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAccounts", "HashPassword", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.UserAccounts", "SaltPassword", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAccounts", "SaltPassword", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.UserAccounts", "HashPassword", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
    }
}
