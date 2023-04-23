using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_CodeFirst_LINQ.Migrations
{
    public partial class TestSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConnID",
                table: "subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnID",
                table: "subjects");
        }
    }
}
