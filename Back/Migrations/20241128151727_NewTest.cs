using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Back.Migrations
{
    /// <inheritdoc />
    public partial class NewTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteSportUserInfo_UserInfos_UserInfosesId",
                table: "FavouriteSportUserInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Requests_RequestId",
                table: "Tournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserInfos_UserInfoId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserInfoId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_RequestId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Tournaments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserInfos",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserInfosesId",
                table: "FavouriteSportUserInfo",
                newName: "UserInfosUserId");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteSportUserInfo_UserInfosesId",
                table: "FavouriteSportUserInfo",
                newName: "IX_FavouriteSportUserInfo_UserInfosUserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserInfos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "Requests",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TournamentId",
                table: "Requests",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteSportUserInfo_UserInfos_UserInfosUserId",
                table: "FavouriteSportUserInfo",
                column: "UserInfosUserId",
                principalTable: "UserInfos",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Tournaments_TournamentId",
                table: "Requests",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_Users_UserId",
                table: "UserInfos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteSportUserInfo_UserInfos_UserInfosUserId",
                table: "FavouriteSportUserInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Tournaments_TournamentId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_Users_UserId",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_Requests_TournamentId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserInfos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserInfosUserId",
                table: "FavouriteSportUserInfo",
                newName: "UserInfosesId");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteSportUserInfo_UserInfosUserId",
                table: "FavouriteSportUserInfo",
                newName: "IX_FavouriteSportUserInfo_UserInfosesId");

            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserInfos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Tournaments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserInfoId",
                table: "Users",
                column: "UserInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_RequestId",
                table: "Tournaments",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteSportUserInfo_UserInfos_UserInfosesId",
                table: "FavouriteSportUserInfo",
                column: "UserInfosesId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Requests_RequestId",
                table: "Tournaments",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserInfos_UserInfoId",
                table: "Users",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
