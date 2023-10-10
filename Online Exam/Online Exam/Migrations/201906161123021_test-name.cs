namespace Online_Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testname : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TestModels", newName: "Tests");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Tests", newName: "TestModels");
        }
    }
}
