using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Model.Migrations
{
    /// <inheritdoc />
    public partial class avv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Start",
                table: "Subject",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Start",
                table: "Subject");
        }
    }
}
