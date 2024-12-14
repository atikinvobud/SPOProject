using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    /// <inheritdoc />
    public partial class nulableCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_NotACities_CityId",
                table: "UserInfos");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "UserInfos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_NotACities_CityId",
                table: "UserInfos",
                column: "CityId",
                principalTable: "NotACities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_NotACities_CityId",
                table: "UserInfos");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "UserInfos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_NotACities_CityId",
                table: "UserInfos",
                column: "CityId",
                principalTable: "NotACities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
