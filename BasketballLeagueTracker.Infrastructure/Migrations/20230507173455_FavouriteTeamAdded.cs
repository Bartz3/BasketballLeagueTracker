using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballLeagueTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FavouriteTeamAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouritePlayers_AspNetUsers_UserId",
                table: "FavouritePlayers");

            migrationBuilder.CreateTable(
                name: "FavouriteTeams",
                columns: table => new
                {
                    FavouriteTeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteTeams", x => x.FavouriteTeamId);
                    table.ForeignKey(
                        name: "FK_FavouriteTeams_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteTeams_TeamId",
                table: "FavouriteTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteTeams_UserId",
                table: "FavouriteTeams",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritePlayers_AspNetUsers_UserId",
                table: "FavouritePlayers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouritePlayers_AspNetUsers_UserId",
                table: "FavouritePlayers");

            migrationBuilder.DropTable(
                name: "FavouriteTeams");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritePlayers_AspNetUsers_UserId",
                table: "FavouritePlayers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
