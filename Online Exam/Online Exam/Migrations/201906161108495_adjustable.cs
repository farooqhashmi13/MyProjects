namespace Online_Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adjustable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestQuestions", "QuestionsId", "dbo.Questions");
            DropForeignKey("dbo.TestQuestions", "TestId", "dbo.TestModels");
            DropIndex("dbo.TestQuestions", new[] { "TestId" });
            DropIndex("dbo.TestQuestions", new[] { "QuestionsId" });
            AddColumn("dbo.TestModels", "TestDateTime", c => c.DateTime());
            AddColumn("dbo.TestModels", "TimeTaken", c => c.DateTime());
            AlterColumn("dbo.TestModels", "Score", c => c.Int());
            AlterColumn("dbo.TestQuestions", "TestId", c => c.Int());
            AlterColumn("dbo.TestQuestions", "QuestionsId", c => c.Int());
            CreateIndex("dbo.TestQuestions", "TestId");
            CreateIndex("dbo.TestQuestions", "QuestionsId");
            AddForeignKey("dbo.TestQuestions", "QuestionsId", "dbo.Questions", "Id");
            AddForeignKey("dbo.TestQuestions", "TestId", "dbo.TestModels", "Id");
            DropColumn("dbo.TestModels", "DateTime");
            DropColumn("dbo.TestQuestions", "Answer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestQuestions", "Answer", c => c.String());
            AddColumn("dbo.TestModels", "DateTime", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.TestQuestions", "TestId", "dbo.TestModels");
            DropForeignKey("dbo.TestQuestions", "QuestionsId", "dbo.Questions");
            DropIndex("dbo.TestQuestions", new[] { "QuestionsId" });
            DropIndex("dbo.TestQuestions", new[] { "TestId" });
            AlterColumn("dbo.TestQuestions", "QuestionsId", c => c.Int(nullable: false));
            AlterColumn("dbo.TestQuestions", "TestId", c => c.Int(nullable: false));
            AlterColumn("dbo.TestModels", "Score", c => c.Int(nullable: false));
            DropColumn("dbo.TestModels", "TimeTaken");
            DropColumn("dbo.TestModels", "TestDateTime");
            CreateIndex("dbo.TestQuestions", "QuestionsId");
            CreateIndex("dbo.TestQuestions", "TestId");
            AddForeignKey("dbo.TestQuestions", "TestId", "dbo.TestModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TestQuestions", "QuestionsId", "dbo.Questions", "Id", cascadeDelete: true);
        }
    }
}
