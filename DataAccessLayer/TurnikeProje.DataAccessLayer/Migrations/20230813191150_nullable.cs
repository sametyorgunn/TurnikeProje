using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurnikeProje.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InOutTimes_Users_UserId",
                table: "InOutTimes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "InOutTimes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InOutTimes_Users_UserId",
                table: "InOutTimes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InOutTimes_Users_UserId",
                table: "InOutTimes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "InOutTimes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_InOutTimes_Users_UserId",
                table: "InOutTimes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
