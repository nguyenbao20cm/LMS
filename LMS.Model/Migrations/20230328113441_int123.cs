using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Model.Migrations
{
    /// <inheritdoc />
    public partial class int123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    StudentSubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    ClassRoomID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => x.StudentSubjectId);
                    table.ForeignKey(
                        name: "FK_StudentSubject_ClassRoom_ClassRoomID",
                        column: x => x.ClassRoomID,
                        principalTable: "ClassRoom",
                        principalColumn: "ClassRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_TaiKhoan_AccountID",
                        column: x => x.AccountID,
                        principalTable: "TaiKhoan",
                        principalColumn: "TaiKhoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_AccountID",
                table: "StudentSubject",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_ClassRoomID",
                table: "StudentSubject",
                column: "ClassRoomID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectID",
                table: "StudentSubject",
                column: "SubjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubject");
        }
    }
}
