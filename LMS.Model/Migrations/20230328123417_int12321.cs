using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Model.Migrations
{
    /// <inheritdoc />
    public partial class int12321 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Start",
                table: "Subject");

            migrationBuilder.AddColumn<bool>(
                name: "Start",
                table: "StudentSubject",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Start",
                table: "StudentSubject");

            migrationBuilder.AddColumn<bool>(
                name: "Start",
                table: "Subject",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
