using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tournament.API.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class JumpAttemptKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JumpAttempt",
                table: "JumpAttempt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JumpAttempt",
                table: "JumpAttempt",
                columns: new[] { "TournamentId", "ParticipantId", "Distance" })
                .Annotation("SqlServer:Clustered", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JumpAttempt",
                table: "JumpAttempt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JumpAttempt",
                table: "JumpAttempt",
                columns: new[] { "TournamentId", "ParticipantId", "Distance" });
        }
    }
}
