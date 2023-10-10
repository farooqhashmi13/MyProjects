namespace Online_Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestQuestions", "OptionId", c => c.Int());
            CreateIndex("dbo.TestQuestions", "OptionId");
            AddForeignKey("dbo.TestQuestions", "OptionId", "dbo.Options", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestQuestions", "OptionId", "dbo.Options");
            DropIndex("dbo.TestQuestions", new[] { "OptionId" });
            DropColumn("dbo.TestQuestions", "OptionId");
        }
    }
}
