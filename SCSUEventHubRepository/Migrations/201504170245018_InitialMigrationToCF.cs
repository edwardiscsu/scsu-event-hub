namespace SCSUEventHubRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrationToCF : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 4000),
                        FirstName = c.String(maxLength: 4000),
                        LastName = c.String(maxLength: 4000),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 4000),
                        SecurityStamp = c.String(maxLength: 4000),
                        PhoneNumber = c.String(maxLength: 4000),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 4000),
                        ClaimType = c.String(maxLength: 4000),
                        ClaimValue = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 4000),
                        ProviderKey = c.String(nullable: false, maxLength: 4000),
                        UserId = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 4000),
                        RoleId = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdminID = c.Int(),
                        CategoryName = c.String(maxLength: 4000),
                        Admin_Id = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.Admin_Id)
                .Index(t => t.Admin_Id);
            
            CreateTable(
                "dbo.CategorySubscriptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(),
                        UserID = c.Int(),
                        User_Id = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.CategoryID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Recommendations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(),
                        UserID = c.Int(),
                        User_Id = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Events", t => t.EventID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.EventID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(),
                        AdminID = c.Int(),
                        EventName = c.String(maxLength: 4000),
                        DateTime = c.DateTime(),
                        ImageURL = c.String(maxLength: 4000),
                        Description = c.String(maxLength: 4000),
                        Admin_Id = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.Admin_Id)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID)
                .Index(t => t.Admin_Id);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(),
                        UserID = c.Int(),
                        User_Id = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Events", t => t.EventID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.EventID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubscriptionID = c.Int(),
                        DateTime = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Subscriptions", t => t.SubscriptionID)
                .Index(t => t.SubscriptionID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 4000),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Recommendations", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subscriptions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reminders", "SubscriptionID", "dbo.Subscriptions");
            DropForeignKey("dbo.Subscriptions", "EventID", "dbo.Events");
            DropForeignKey("dbo.Recommendations", "EventID", "dbo.Events");
            DropForeignKey("dbo.Events", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Events", "Admin_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CategorySubscriptions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CategorySubscriptions", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Admin_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Reminders", new[] { "SubscriptionID" });
            DropIndex("dbo.Subscriptions", new[] { "User_Id" });
            DropIndex("dbo.Subscriptions", new[] { "EventID" });
            DropIndex("dbo.Events", new[] { "Admin_Id" });
            DropIndex("dbo.Events", new[] { "CategoryID" });
            DropIndex("dbo.Recommendations", new[] { "User_Id" });
            DropIndex("dbo.Recommendations", new[] { "EventID" });
            DropIndex("dbo.CategorySubscriptions", new[] { "User_Id" });
            DropIndex("dbo.CategorySubscriptions", new[] { "CategoryID" });
            DropIndex("dbo.Categories", new[] { "Admin_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Reminders");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.Events");
            DropTable("dbo.Recommendations");
            DropTable("dbo.CategorySubscriptions");
            DropTable("dbo.Categories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
        }
    }
}
