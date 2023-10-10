namespace NewOnlineExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewOnlineExamDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Option = c.String(),
                        IsAnswer = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        CategoryId = c.Int(nullable: false),
                        subCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubCategories", t => t.subCategory_Id)
                .Index(t => t.subCategory_Id);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestDateTime = c.DateTime(),
                        TimeTaken = c.DateTime(),
                        Score = c.Int(),
                        TotalScore = c.Int(),
                        CategoryId = c.Int(),
                        SubCategoryId = c.Int(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CategoryId)
                .Index(t => t.SubCategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TestQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(),
                        QuestionsId = c.Int(),
                        SelectedOptionId = c.Int(),
                        IsCorrect = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionsId)
                .ForeignKey("dbo.Options", t => t.SelectedOptionId)
                .ForeignKey("dbo.Tests", t => t.TestId)
                .Index(t => t.TestId)
                .Index(t => t.QuestionsId)
                .Index(t => t.SelectedOptionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestQuestions", "TestId", "dbo.Tests");
            DropForeignKey("dbo.TestQuestions", "SelectedOptionId", "dbo.Options");
            DropForeignKey("dbo.TestQuestions", "QuestionsId", "dbo.Questions");
            DropForeignKey("dbo.Tests", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tests", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.Tests", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Options", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "subCategory_Id", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.TestQuestions", new[] { "SelectedOptionId" });
            DropIndex("dbo.TestQuestions", new[] { "QuestionsId" });
            DropIndex("dbo.TestQuestions", new[] { "TestId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Tests", new[] { "UserId" });
            DropIndex("dbo.Tests", new[] { "SubCategoryId" });
            DropIndex("dbo.Tests", new[] { "CategoryId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropIndex("dbo.Questions", new[] { "subCategory_Id" });
            DropIndex("dbo.Options", new[] { "QuestionId" });
            DropTable("dbo.TestQuestions");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tests");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Questions");
            DropTable("dbo.Options");
            DropTable("dbo.Categories");
        }
    }
}
