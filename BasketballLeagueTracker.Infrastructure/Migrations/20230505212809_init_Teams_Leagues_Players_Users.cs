using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballLeagueTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init_Teams_Leagues_Players_Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    StadiumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.StadiumId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WantsToHaveNotification = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ApplicationUserId);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ArticleId);
                    table.ForeignKey(
                        name: "FK_Article_Users_UserApplicationUserId",
                        column: x => x.UserApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "ApplicationUserId");
                });

            migrationBuilder.CreateTable(
                name: "ArticleImage",
                columns: table => new
                {
                    ArticleImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleImage", x => x.ArticleImageId);
                    table.ForeignKey(
                        name: "FK_ArticleImage_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "ArticleId");
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    LeagueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaugeMVPPlayerId = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamLogo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsCurrentlyPlaying = table.Column<bool>(type: "bit", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: true),
                    StadiumId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId");
                    table.ForeignKey(
                        name: "FK_Teams_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "StadiumId");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniformNumber = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GamesPlayed = table.Column<int>(type: "int", nullable: true),
                    IsInTeam = table.Column<bool>(type: "bit", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "SeasonStatistics",
                columns: table => new
                {
                    SeasonStatisticsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    GamesPlayed = table.Column<int>(type: "int", nullable: false),
                    LeaguePoints = table.Column<int>(type: "int", nullable: false),
                    PointsPerGame = table.Column<double>(type: "float", nullable: false),
                    OpponentPointsPerGame = table.Column<double>(type: "float", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonStatistics", x => x.SeasonStatisticsId);
                    table.ForeignKey(
                        name: "FK_SeasonStatistics_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId");
                    table.ForeignKey(
                        name: "FK_SeasonStatistics_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_LeagueId",
                table: "Article",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_UserApplicationUserId",
                table: "Article",
                column: "UserApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleImage_ArticleId",
                table: "ArticleImage",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_LeaugeMVPPlayerId",
                table: "Leagues",
                column: "LeaugeMVPPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonStatistics_LeagueId",
                table: "SeasonStatistics",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonStatistics_TeamId",
                table: "SeasonStatistics",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StadiumId",
                table: "Teams",
                column: "StadiumId",
                unique: true,
                filter: "[StadiumId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Leagues_LeagueId",
                table: "Article",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "LeagueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Players_LeaugeMVPPlayerId",
                table: "Leagues",
                column: "LeaugeMVPPlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "ArticleImage");

            migrationBuilder.DropTable(
                name: "SeasonStatistics");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Stadiums");
        }
    }
}
