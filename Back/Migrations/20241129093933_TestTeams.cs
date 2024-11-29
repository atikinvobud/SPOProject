using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    /// <inheritdoc />
    public partial class TestTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsersUser_TeamsUsers_TeamsUsersId",
                table: "TeamUsersUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsersUser_Users_UsersId",
                table: "TeamUsersUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamUsersUser",
                table: "TeamUsersUser");

            migrationBuilder.RenameTable(
                name: "TeamUsersUser",
                newName: "tu-u");

            migrationBuilder.RenameIndex(
                name: "IX_TeamUsersUser_UsersId",
                table: "tu-u",
                newName: "IX_tu-u_UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tu-u",
                table: "tu-u",
                columns: new[] { "TeamsUsersId", "UsersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_tu-u_TeamsUsers_TeamsUsersId",
                table: "tu-u",
                column: "TeamsUsersId",
                principalTable: "TeamsUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tu-u_Users_UsersId",
                table: "tu-u",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tu-u_TeamsUsers_TeamsUsersId",
                table: "tu-u");

            migrationBuilder.DropForeignKey(
                name: "FK_tu-u_Users_UsersId",
                table: "tu-u");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tu-u",
                table: "tu-u");

            migrationBuilder.RenameTable(
                name: "tu-u",
                newName: "TeamUsersUser");

            migrationBuilder.RenameIndex(
                name: "IX_tu-u_UsersId",
                table: "TeamUsersUser",
                newName: "IX_TeamUsersUser_UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamUsersUser",
                table: "TeamUsersUser",
                columns: new[] { "TeamsUsersId", "UsersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsersUser_TeamsUsers_TeamsUsersId",
                table: "TeamUsersUser",
                column: "TeamsUsersId",
                principalTable: "TeamsUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsersUser_Users_UsersId",
                table: "TeamUsersUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
