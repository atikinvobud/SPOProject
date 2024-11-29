using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    /// <inheritdoc />
    public partial class TestNotACityAndSportFav : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteSportUserInfo_FavouriteSports_FavouriteSportsId",
                table: "FavouriteSportUserInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteSportUserInfo_UserInfos_UserInfosUserId",
                table: "FavouriteSportUserInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteSportUserInfo",
                table: "FavouriteSportUserInfo");

            migrationBuilder.RenameTable(
                name: "FavouriteSportUserInfo",
                newName: "ui-fs");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteSportUserInfo_UserInfosUserId",
                table: "ui-fs",
                newName: "IX_ui-fs_UserInfosUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ui-fs",
                table: "ui-fs",
                columns: new[] { "FavouriteSportsId", "UserInfosUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ui-fs_FavouriteSports_FavouriteSportsId",
                table: "ui-fs",
                column: "FavouriteSportsId",
                principalTable: "FavouriteSports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ui-fs_UserInfos_UserInfosUserId",
                table: "ui-fs",
                column: "UserInfosUserId",
                principalTable: "UserInfos",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ui-fs_FavouriteSports_FavouriteSportsId",
                table: "ui-fs");

            migrationBuilder.DropForeignKey(
                name: "FK_ui-fs_UserInfos_UserInfosUserId",
                table: "ui-fs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ui-fs",
                table: "ui-fs");

            migrationBuilder.RenameTable(
                name: "ui-fs",
                newName: "FavouriteSportUserInfo");

            migrationBuilder.RenameIndex(
                name: "IX_ui-fs_UserInfosUserId",
                table: "FavouriteSportUserInfo",
                newName: "IX_FavouriteSportUserInfo_UserInfosUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteSportUserInfo",
                table: "FavouriteSportUserInfo",
                columns: new[] { "FavouriteSportsId", "UserInfosUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteSportUserInfo_FavouriteSports_FavouriteSportsId",
                table: "FavouriteSportUserInfo",
                column: "FavouriteSportsId",
                principalTable: "FavouriteSports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteSportUserInfo_UserInfos_UserInfosUserId",
                table: "FavouriteSportUserInfo",
                column: "UserInfosUserId",
                principalTable: "UserInfos",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
