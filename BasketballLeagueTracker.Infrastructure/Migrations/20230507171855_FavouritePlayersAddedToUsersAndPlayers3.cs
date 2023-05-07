using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballLeagueTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FavouritePlayersAddedToUsersAndPlayers3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouritePlayers_AspNetUsers_UserId1",
                table: "FavouritePlayers");

            migrationBuilder.DropIndex(
                name: "IX_FavouritePlayers_UserId1",
                table: "FavouritePlayers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "FavouritePlayers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FavouritePlayers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_FavouritePlayers_UserId",
                table: "FavouritePlayers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritePlayers_AspNetUsers_UserId",
                table: "FavouritePlayers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouritePlayers_AspNetUsers_UserId",
                table: "FavouritePlayers");

            migrationBuilder.DropIndex(
                name: "IX_FavouritePlayers_UserId",
                table: "FavouritePlayers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "FavouritePlayers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "FavouritePlayers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_FavouritePlayers_UserId1",
                table: "FavouritePlayers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritePlayers_AspNetUsers_UserId1",
                table: "FavouritePlayers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
