namespace NewOnlineExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resume : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Title = c.String(),
                        Institute = c.String(),
                        DateStart = c.String(),
                        DateEnd = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        CompanyName = c.String(),
                        JobTitle = c.String(),
                        StartDate = c.String(),
                        EndDate = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.JobTitles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Title = c.String(),
                        Link = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobTitles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Experiences", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Educations", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "UserId" });
            DropIndex("dbo.JobTitles", new[] { "UserId" });
            DropIndex("dbo.Experiences", new[] { "UserId" });
            DropIndex("dbo.Educations", new[] { "UserId" });
            DropTable("dbo.Projects");
            DropTable("dbo.JobTitles");
            DropTable("dbo.Experiences");
            DropTable("dbo.Educations");
        }
    }
}
