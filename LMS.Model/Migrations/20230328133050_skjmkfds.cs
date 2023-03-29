using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Model.Migrations
{
    /// <inheritdoc />
    public partial class skjmkfds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountTeacherId",
                table: "StudentSubject",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountTeacherId",
                table: "StudentSubject");
        }
    }
}
