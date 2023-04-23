using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_CodeFirst_LINQ.Migrations
{
    public partial class TeacherRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teachers_connects_TconnectConnectID",
                table: "teachers");

            migrationBuilder.RenameColumn(
                name: "TconnectConnectID",
                table: "teachers",
                newName: "ConnectID");

            migrationBuilder.RenameIndex(
                name: "IX_teachers_TconnectConnectID",
                table: "teachers",
                newName: "IX_teachers_ConnectID");

            migrationBuilder.AddForeignKey(
                name: "FK_teachers_connects_ConnectID",
                table: "teachers",
                column: "ConnectID",
                principalTable: "connects",
                principalColumn: "ConnectID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teachers_connects_ConnectID",
                table: "teachers");

            migrationBuilder.RenameColumn(
                name: "ConnectID",
                table: "teachers",
                newName: "TconnectConnectID");

            migrationBuilder.RenameIndex(
                name: "IX_teachers_ConnectID",
                table: "teachers",
                newName: "IX_teachers_TconnectConnectID");

            migrationBuilder.AddForeignKey(
                name: "FK_teachers_connects_TconnectConnectID",
                table: "teachers",
                column: "TconnectConnectID",
                principalTable: "connects",
                principalColumn: "ConnectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
