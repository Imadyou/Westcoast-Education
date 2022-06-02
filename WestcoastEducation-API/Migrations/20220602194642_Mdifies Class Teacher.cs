using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WestcoastEducation_API.Migrations
{
    public partial class MdifiesClassTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Teachers_TeacherId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_TeacherId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Teachers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Teachers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherId",
                table: "Teachers",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Teachers_TeacherId",
                table: "Teachers",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
