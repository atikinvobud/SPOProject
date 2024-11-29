using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    /// <inheritdoc />
    public partial class UserInfoTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Cities_CityId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_Cities_CityId",
                table: "UserInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "NotACities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotACities",
                table: "NotACities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_NotACities_CityId",
                table: "Locations",
                column: "CityId",
                principalTable: "NotACities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_NotACities_CityId",
                table: "UserInfos",
                column: "CityId",
                principalTable: "NotACities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_NotACities_CityId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_NotACities_CityId",
                table: "UserInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotACities",
                table: "NotACities");

            migrationBuilder.RenameTable(
                name: "NotACities",
                newName: "Cities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Cities_CityId",
                table: "Locations",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_Cities_CityId",
                table: "UserInfos",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
