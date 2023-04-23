using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_CodeFirst_LINQ.Migrations
{
    public partial class Test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teachers_connects_ConnectID",
                table: "teachers");

            migrationBuilder.AlterColumn<int>(
                name: "ConnectID",
                table: "teachers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_teachers_connects_ConnectID",
                table: "teachers",
                column: "ConnectID",
                principalTable: "connects",
                principalColumn: "ConnectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teachers_connects_ConnectID",
                table: "teachers");

            migrationBuilder.AlterColumn<int>(
                name: "ConnectID",
                table: "teachers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_teachers_connects_ConnectID",
                table: "teachers",
                column: "ConnectID",
                principalTable: "connects",
                principalColumn: "ConnectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
