using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_WEB_APP.Migrations
{
    public partial class StudentSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    syllabus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    credits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_SubjectId",
                table: "Student",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Subject_SubjectId",
                table: "Student",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Subject_SubjectId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Student_SubjectId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Student");
        }
    }
}
