using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_CodeFirst_LINQ.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_connects_SubjectID",
                table: "connects");

            migrationBuilder.CreateIndex(
                name: "IX_connects_SubjectID",
                table: "connects",
                column: "SubjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_connects_SubjectID",
                table: "connects");

            migrationBuilder.CreateIndex(
                name: "IX_connects_SubjectID",
                table: "connects",
                column: "SubjectID",
                unique: true);
        }
    }
}
