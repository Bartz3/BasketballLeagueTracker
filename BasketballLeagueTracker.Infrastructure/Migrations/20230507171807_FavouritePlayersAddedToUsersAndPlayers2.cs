using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballLeagueTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FavouritePlayersAddedToUsersAndPlayers2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouritePlayer_AspNetUsers_UserId1",
                table: "FavouritePlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouritePlayer_Players_PlayerId",
                table: "FavouritePlayer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouritePlayer",
                table: "FavouritePlayer");

            migrationBuilder.RenameTable(
                name: "FavouritePlayer",
                newName: "FavouritePlayers");

            migrationBuilder.RenameIndex(
                name: "IX_FavouritePlayer_UserId1",
                table: "FavouritePlayers",
                newName: "IX_FavouritePlayers_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_FavouritePlayer_PlayerId",
                table: "FavouritePlayers",
                newName: "IX_FavouritePlayers_PlayerId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId1",
                table: "FavouritePlayers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouritePlayers",
                table: "FavouritePlayers",
                column: "FavouritePlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritePlayers_AspNetUsers_UserId1",
                table: "FavouritePlayers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritePlayers_Players_PlayerId",
                table: "FavouritePlayers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouritePlayers_AspNetUsers_UserId1",
                table: "FavouritePlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouritePlayers_Players_PlayerId",
                table: "FavouritePlayers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouritePlayers",
                table: "FavouritePlayers");

            migrationBuilder.RenameTable(
                name: "FavouritePlayers",
                newName: "FavouritePlayer");

            migrationBuilder.RenameIndex(
                name: "IX_FavouritePlayers_UserId1",
                table: "FavouritePlayer",
                newName: "IX_FavouritePlayer_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_FavouritePlayers_PlayerId",
                table: "FavouritePlayer",
                newName: "IX_FavouritePlayer_PlayerId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId1",
                table: "FavouritePlayer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouritePlayer",
                table: "FavouritePlayer",
                column: "FavouritePlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritePlayer_AspNetUsers_UserId1",
                table: "FavouritePlayer",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritePlayer_Players_PlayerId",
                table: "FavouritePlayer",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
