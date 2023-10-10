namespace NewOnlineExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identityprops : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}
