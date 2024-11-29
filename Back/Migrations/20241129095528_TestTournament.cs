using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    /// <inheritdoc />
    public partial class TestTournament : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Tournaments_TournamentId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_DateId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_NotificationId",
                table: "Tournaments");

            migrationBuilder.AlterColumn<int>(
                name: "TournamentId",
                table: "Requests",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_DateId",
                table: "Tournaments",
                column: "DateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_NotificationId",
                table: "Tournaments",
                column: "NotificationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Tournaments_TournamentId",
                table: "Requests",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Tournaments_TournamentId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_DateId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_NotificationId",
                table: "Tournaments");

            migrationBuilder.AlterColumn<int>(
                name: "TournamentId",
                table: "Requests",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_DateId",
                table: "Tournaments",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_NotificationId",
                table: "Tournaments",
                column: "NotificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Tournaments_TournamentId",
                table: "Requests",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id");
        }
    }
}
