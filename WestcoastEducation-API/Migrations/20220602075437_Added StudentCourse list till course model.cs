using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WestcoastEducation_API.Migrations
{
    public partial class AddedStudentCourselisttillcoursemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Categories",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Teachers_TeacherId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Categories_TeacherId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Categories");
        }
    }
}
