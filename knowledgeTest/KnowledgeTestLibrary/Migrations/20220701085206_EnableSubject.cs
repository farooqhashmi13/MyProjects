using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowledgeTestLibrary.Migrations
{
    public partial class EnableSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Subjects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Subjects");
        }
    }
}
