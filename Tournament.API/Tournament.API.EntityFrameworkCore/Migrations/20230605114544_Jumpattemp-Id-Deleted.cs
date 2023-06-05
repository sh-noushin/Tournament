using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tournament.API.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class JumpattempIdDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "JumpAttempts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "JumpAttempts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
