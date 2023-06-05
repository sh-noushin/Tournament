using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tournament.API.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class JumpAttemptEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JumpAttempt_Participants_ParticipantId",
                table: "JumpAttempt");

            migrationBuilder.DropForeignKey(
                name: "FK_JumpAttempt_Tournaments_TournamentId",
                table: "JumpAttempt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JumpAttempt",
                table: "JumpAttempt");

            migrationBuilder.RenameTable(
                name: "JumpAttempt",
                newName: "JumpAttempts");

            migrationBuilder.RenameIndex(
                name: "IX_JumpAttempt_ParticipantId",
                table: "JumpAttempts",
                newName: "IX_JumpAttempts_ParticipantId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "JumpAttempts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JumpAttempts",
                table: "JumpAttempts",
                columns: new[] { "TournamentId", "ParticipantId", "Distance" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddForeignKey(
                name: "FK_JumpAttempts_Participants_ParticipantId",
                table: "JumpAttempts",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JumpAttempts_Tournaments_TournamentId",
                table: "JumpAttempts",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JumpAttempts_Participants_ParticipantId",
                table: "JumpAttempts");

            migrationBuilder.DropForeignKey(
                name: "FK_JumpAttempts_Tournaments_TournamentId",
                table: "JumpAttempts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JumpAttempts",
                table: "JumpAttempts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "JumpAttempts");

            migrationBuilder.RenameTable(
                name: "JumpAttempts",
                newName: "JumpAttempt");

            migrationBuilder.RenameIndex(
                name: "IX_JumpAttempts_ParticipantId",
                table: "JumpAttempt",
                newName: "IX_JumpAttempt_ParticipantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JumpAttempt",
                table: "JumpAttempt",
                columns: new[] { "TournamentId", "ParticipantId", "Distance" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddForeignKey(
                name: "FK_JumpAttempt_Participants_ParticipantId",
                table: "JumpAttempt",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JumpAttempt_Tournaments_TournamentId",
                table: "JumpAttempt",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
