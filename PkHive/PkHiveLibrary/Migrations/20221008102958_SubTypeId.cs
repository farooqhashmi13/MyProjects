using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PkHiveLibrary.Migrations
{
    public partial class SubTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_SubTypes_SubTypeId",
                table: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "SubTypeId",
                table: "Jobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_SubTypes_SubTypeId",
                table: "Jobs",
                column: "SubTypeId",
                principalTable: "SubTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_SubTypes_SubTypeId",
                table: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "SubTypeId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_SubTypes_SubTypeId",
                table: "Jobs",
                column: "SubTypeId",
                principalTable: "SubTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
