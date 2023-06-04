using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tournament.API.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class UndoChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_JumpAttempt_ParticipantId",
                table: "JumpAttempt",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_JumpAttempt_Participants_ParticipantId",
                table: "JumpAttempt",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JumpAttempt_Participants_ParticipantId",
                table: "JumpAttempt");

            migrationBuilder.DropIndex(
                name: "IX_JumpAttempt_ParticipantId",
                table: "JumpAttempt");
        }
    }
}
