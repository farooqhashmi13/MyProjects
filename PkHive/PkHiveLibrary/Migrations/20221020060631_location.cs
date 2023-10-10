using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PkHiveLibrary.Migrations
{
    public partial class location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_SubTypes_SubTypeId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_Options_SelectedOptionId",
                table: "TestQuestions");

            migrationBuilder.DropTable(
                name: "SubTypes");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_SubTypeId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "SubTypeId",
                table: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "SelectedOptionId",
                table: "TestQuestions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Jobs",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmploymentType",
                table: "Jobs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxSalary",
                table: "Jobs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinSalary",
                table: "Jobs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobLocations_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobLocations_JobId",
                table: "JobLocations",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobLocations_LocationId",
                table: "JobLocations",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Options_SelectedOptionId",
                table: "TestQuestions",
                column: "SelectedOptionId",
                principalTable: "Options",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_Options_SelectedOptionId",
                table: "TestQuestions");

            migrationBuilder.DropTable(
                name: "JobLocations");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropColumn(
                name: "EmploymentType",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "MaxSalary",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "MinSalary",
                table: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "SelectedOptionId",
                table: "TestQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Jobs",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubTypeId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTypes_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_SubTypeId",
                table: "Jobs",
                column: "SubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTypes_JobTypeId",
                table: "SubTypes",
                column: "JobTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_SubTypes_SubTypeId",
                table: "Jobs",
                column: "SubTypeId",
                principalTable: "SubTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Options_SelectedOptionId",
                table: "TestQuestions",
                column: "SelectedOptionId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
