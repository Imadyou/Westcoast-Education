using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WestcoastEducation_API.Migrations
{
    public partial class AddedRelationsTeacherswithCoursesandCategoriswithTeachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Teachers_TeacherId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_TeacherId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Teachers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoriesTeachers",
                columns: table => new
                {
                    CompetencisId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeachersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesTeachers", x => new { x.CompetencisId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_CategoriesTeachers_Categories_CompetencisId",
                        column: x => x.CompetencisId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesTeachers_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachersCourses",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeachersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersCourses", x => new { x.CoursesId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_TeachersCourses_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeachersCourses_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherId",
                table: "Teachers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesTeachers_TeachersId",
                table: "CategoriesTeachers",
                column: "TeachersId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersCourses_TeachersId",
                table: "TeachersCourses",
                column: "TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Teachers_TeacherId",
                table: "Teachers",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Teachers_TeacherId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "CategoriesTeachers");

            migrationBuilder.DropTable(
                name: "TeachersCourses");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_TeacherId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Categories",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TeacherId",
                table: "Categories",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Teachers_TeacherId",
                table: "Categories",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
