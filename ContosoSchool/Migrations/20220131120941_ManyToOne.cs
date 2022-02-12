using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoSchool.Migrations
{
    public partial class ManyToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentTeacher");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Student_TeacherId",
                table: "Student",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Teacher_TeacherId",
                table: "Student",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Teacher_TeacherId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_TeacherId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Student");

            migrationBuilder.CreateTable(
                name: "StudentTeacher",
                columns: table => new
                {
                    StudentTeachersId = table.Column<int>(type: "int", nullable: false),
                    TeacherStudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTeacher", x => new { x.StudentTeachersId, x.TeacherStudentsId });
                    table.ForeignKey(
                        name: "FK_StudentTeacher_Student_TeacherStudentsId",
                        column: x => x.TeacherStudentsId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTeacher_Teacher_StudentTeachersId",
                        column: x => x.StudentTeachersId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeacher_TeacherStudentsId",
                table: "StudentTeacher",
                column: "TeacherStudentsId");
        }
    }
}
