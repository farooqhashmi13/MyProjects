using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PkHiveLibrary.Migrations
{
    public partial class ApplyLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    JobTypeId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PayScale = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Vacancies = table.Column<int>(type: "int", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ApplyLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    SubTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_JobTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_SubTypes_SubTypeId",
                        column: x => x.SubTypeId,
                        principalTable: "SubTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_SubTypeId",
                table: "Jobs",
                column: "SubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_TypeId",
                table: "Jobs",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTypes_JobTypeId",
                table: "SubTypes",
                column: "JobTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "SubTypes");

            migrationBuilder.DropTable(
                name: "JobTypes");
        }
    }
}
