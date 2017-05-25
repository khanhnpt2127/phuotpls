namespace PhuotApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FollowerId = c.Int(nullable: false),
                        UserProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.UserId, t.FollowerId })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id)
                .Index(t => t.UserProfile_Id);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        HashPassword = c.String(nullable: false, maxLength: 8000, unicode: false),
                        SaltPassword = c.Binary(nullable: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        EmailConfirmToken = c.String(maxLength: 8000, unicode: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccountStatus", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.UserAccountStatus",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Bio = c.String(maxLength: 300),
                        Email = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        PhoneNumber = c.String(),
                        PictureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserPictureProfiles",
                c => new
                    {
                        PictureId = c.Int(nullable: false),
                        PictureProfile = c.Binary(),
                    })
                .PrimaryKey(t => t.PictureId)
                .ForeignKey("dbo.UserProfiles", t => t.PictureId)
                .Index(t => t.PictureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccounts", "Id", "dbo.UserProfiles");
            DropForeignKey("dbo.UserPictureProfiles", "PictureId", "dbo.UserProfiles");
            DropForeignKey("dbo.Followers", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.UserAccounts", "StatusId", "dbo.UserAccountStatus");
            DropIndex("dbo.UserPictureProfiles", new[] { "PictureId" });
            DropIndex("dbo.UserAccounts", new[] { "StatusId" });
            DropIndex("dbo.UserAccounts", new[] { "Id" });
            DropIndex("dbo.Followers", new[] { "UserProfile_Id" });
            DropTable("dbo.UserPictureProfiles");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.UserAccountStatus");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Followers");
        }
    }
}
