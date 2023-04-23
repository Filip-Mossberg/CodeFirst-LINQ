using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_CodeFirst_LINQ.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "connects",
                columns: table => new
                {
                    ConnectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_connects", x => x.ConnectID);
                    table.ForeignKey(
                        name: "FK_connects_subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudconnectConnectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_student_connects_StudconnectConnectID",
                        column: x => x.StudconnectConnectID,
                        principalTable: "connects",
                        principalColumn: "ConnectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TconnectConnectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.TeacherID);
                    table.ForeignKey(
                        name: "FK_teachers_connects_TconnectConnectID",
                        column: x => x.TconnectConnectID,
                        principalTable: "connects",
                        principalColumn: "ConnectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_connects_SubjectID",
                table: "connects",
                column: "SubjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_student_StudconnectConnectID",
                table: "student",
                column: "StudconnectConnectID");

            migrationBuilder.CreateIndex(
                name: "IX_teachers_TconnectConnectID",
                table: "teachers",
                column: "TconnectConnectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "connects");

            migrationBuilder.DropTable(
                name: "subjects");
        }
    }
}
