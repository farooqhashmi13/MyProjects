namespace NewOnlineExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestQuestions", "QuestionNo", c => c.Int(nullable: false));
            AlterColumn("dbo.Tests", "TimeTaken", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tests", "TimeTaken", c => c.DateTime());
            DropColumn("dbo.TestQuestions", "QuestionNo");
        }
    }
}
