using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballLeagueTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GameAndStatsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCommentRating_AspNetUsers_UserId",
                table: "UserCommentRating");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCommentRating_Comment_CommentId",
                table: "UserCommentRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCommentRating",
                table: "UserCommentRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "UserCommentRating",
                newName: "UserCommentRatings");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_UserCommentRating_UserId",
                table: "UserCommentRatings",
                newName: "IX_UserCommentRatings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCommentRating_CommentId",
                table: "UserCommentRatings",
                newName: "IX_UserCommentRatings_CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCommentRatings",
                table: "UserCommentRatings",
                column: "UserCommentRatingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    HomeTeamScore = table.Column<int>(type: "int", nullable: false),
                    AwayTeamScore = table.Column<int>(type: "int", nullable: false),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId");
                    table.ForeignKey(
                        name: "FK_Games_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                    table.ForeignKey(
                        name: "FK_Games_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "GamePlayerStats",
                columns: table => new
                {
                    GamePlayerStatsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Points = table.Column<int>(type: "int", nullable: true),
                    TimeSpend = table.Column<int>(type: "int", nullable: true),
                    Rebounds = table.Column<int>(type: "int", nullable: true),
                    OffensiveRebounds = table.Column<int>(type: "int", nullable: true),
                    DefensiveRebounds = table.Column<int>(type: "int", nullable: true),
                    Assists = table.Column<int>(type: "int", nullable: true),
                    Steals = table.Column<int>(type: "int", nullable: true),
                    Blocks = table.Column<int>(type: "int", nullable: true),
                    Turnovers = table.Column<int>(type: "int", nullable: true),
                    Fouls = table.Column<int>(type: "int", nullable: true),
                    IsOnBench = table.Column<bool>(type: "bit", nullable: true),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayerStats", x => x.GamePlayerStatsId);
                    table.ForeignKey(
                        name: "FK_GamePlayerStats_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId");
                    table.ForeignKey(
                        name: "FK_GamePlayerStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayerStats_GameId",
                table: "GamePlayerStats",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayerStats_PlayerId",
                table: "GamePlayerStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_AwayTeamId",
                table: "Games",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeTeamId",
                table: "Games",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_LeagueId",
                table: "Games",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCommentRatings_AspNetUsers_UserId",
                table: "UserCommentRatings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCommentRatings_Comments_CommentId",
                table: "UserCommentRatings",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCommentRatings_AspNetUsers_UserId",
                table: "UserCommentRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCommentRatings_Comments_CommentId",
                table: "UserCommentRatings");

            migrationBuilder.DropTable(
                name: "GamePlayerStats");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCommentRatings",
                table: "UserCommentRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "UserCommentRatings",
                newName: "UserCommentRating");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_UserCommentRatings_UserId",
                table: "UserCommentRating",
                newName: "IX_UserCommentRating_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCommentRatings_CommentId",
                table: "UserCommentRating",
                newName: "IX_UserCommentRating_CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comment",
                newName: "IX_Comment_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCommentRating",
                table: "UserCommentRating",
                column: "UserCommentRatingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCommentRating_AspNetUsers_UserId",
                table: "UserCommentRating",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCommentRating_Comment_CommentId",
                table: "UserCommentRating",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
