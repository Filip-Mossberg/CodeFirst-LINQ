using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_CodeFirst_LINQ.Migrations
{
    public partial class Test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teachers_connects_ConnectID",
                table: "teachers");

            migrationBuilder.DropIndex(
                name: "IX_teachers_ConnectID",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "ConnectID",
                table: "teachers");

            migrationBuilder.AddColumn<int>(
                name: "TconnectConnectID",
                table: "teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_teachers_TconnectConnectID",
                table: "teachers",
                column: "TconnectConnectID");

            migrationBuilder.AddForeignKey(
                name: "FK_teachers_connects_TconnectConnectID",
                table: "teachers",
                column: "TconnectConnectID",
                principalTable: "connects",
                principalColumn: "ConnectID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teachers_connects_TconnectConnectID",
                table: "teachers");

            migrationBuilder.DropIndex(
                name: "IX_teachers_TconnectConnectID",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "TconnectConnectID",
                table: "teachers");

            migrationBuilder.AddColumn<int>(
                name: "ConnectID",
                table: "teachers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_teachers_ConnectID",
                table: "teachers",
                column: "ConnectID");

            migrationBuilder.AddForeignKey(
                name: "FK_teachers_connects_ConnectID",
                table: "teachers",
                column: "ConnectID",
                principalTable: "connects",
                principalColumn: "ConnectID");
        }
    }
}
