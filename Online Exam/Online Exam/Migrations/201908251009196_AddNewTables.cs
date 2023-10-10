namespace Online_Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "QuestionCategories");
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
                "dbo.TestCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Questions", "Option1");
            DropColumn("dbo.Questions", "Option2");
            DropColumn("dbo.Questions", "Option3");
            DropColumn("dbo.Questions", "Option4");
            DropColumn("dbo.Questions", "Answer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Answer", c => c.String());
            AddColumn("dbo.Questions", "Option4", c => c.String());
            AddColumn("dbo.Questions", "Option3", c => c.String());
            AddColumn("dbo.Questions", "Option2", c => c.String());
            AddColumn("dbo.Questions", "Option1", c => c.String());
            DropForeignKey("dbo.Options", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Options", new[] { "QuestionId" });
            DropTable("dbo.TestCategories");
            DropTable("dbo.Options");
            RenameTable(name: "dbo.QuestionCategories", newName: "Categories");
        }
    }
}
