using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballTrainingManagement.Migrations
{
    /// <inheritdoc />
    public partial class RenameEntityProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSessionPlayers_Players_playerId",
                table: "TrainingSessionPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSessionPlayers_TrainingSessions_trainingSessionId",
                table: "TrainingSessionPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSessions_Coaches_coachId",
                table: "TrainingSessions");

            migrationBuilder.DropIndex(
                name: "IX_TrainingSessionPlayers_trainingSessionId",
                table: "TrainingSessionPlayers");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "TrainingSessions",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "coachId",
                table: "TrainingSessions",
                newName: "CoachId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TrainingSessions",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingSessions_coachId",
                table: "TrainingSessions",
                newName: "IX_TrainingSessions_CoachId");

            migrationBuilder.RenameColumn(
                name: "trainingSessionId",
                table: "TrainingSessionPlayers",
                newName: "TrainingSessionId");

            migrationBuilder.RenameColumn(
                name: "playerId",
                table: "TrainingSessionPlayers",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TrainingSessionPlayers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingSessionPlayers_playerId",
                table: "TrainingSessionPlayers",
                newName: "IX_TrainingSessionPlayers_PlayerId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Players",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Players",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Players",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Coaches",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Coaches",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSessionPlayers_TrainingSessionId_PlayerId",
                table: "TrainingSessionPlayers",
                columns: new[] { "TrainingSessionId", "PlayerId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSessionPlayers_Players_PlayerId",
                table: "TrainingSessionPlayers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSessionPlayers_TrainingSessions_TrainingSessionId",
                table: "TrainingSessionPlayers",
                column: "TrainingSessionId",
                principalTable: "TrainingSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSessions_Coaches_CoachId",
                table: "TrainingSessions",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSessionPlayers_Players_PlayerId",
                table: "TrainingSessionPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSessionPlayers_TrainingSessions_TrainingSessionId",
                table: "TrainingSessionPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSessions_Coaches_CoachId",
                table: "TrainingSessions");

            migrationBuilder.DropIndex(
                name: "IX_TrainingSessionPlayers_TrainingSessionId_PlayerId",
                table: "TrainingSessionPlayers");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TrainingSessions",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "CoachId",
                table: "TrainingSessions",
                newName: "coachId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TrainingSessions",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingSessions_CoachId",
                table: "TrainingSessions",
                newName: "IX_TrainingSessions_coachId");

            migrationBuilder.RenameColumn(
                name: "TrainingSessionId",
                table: "TrainingSessionPlayers",
                newName: "trainingSessionId");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "TrainingSessionPlayers",
                newName: "playerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TrainingSessionPlayers",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingSessionPlayers_PlayerId",
                table: "TrainingSessionPlayers",
                newName: "IX_TrainingSessionPlayers_playerId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Players",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Players",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Players",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Coaches",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Coaches",
                newName: "id");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSessionPlayers_trainingSessionId",
                table: "TrainingSessionPlayers",
                column: "trainingSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSessionPlayers_Players_playerId",
                table: "TrainingSessionPlayers",
                column: "playerId",
                principalTable: "Players",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSessionPlayers_TrainingSessions_trainingSessionId",
                table: "TrainingSessionPlayers",
                column: "trainingSessionId",
                principalTable: "TrainingSessions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSessions_Coaches_coachId",
                table: "TrainingSessions",
                column: "coachId",
                principalTable: "Coaches",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
