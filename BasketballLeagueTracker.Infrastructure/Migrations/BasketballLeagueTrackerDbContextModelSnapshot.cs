﻿// <auto-generated />
using System;
using BasketballLeagueTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BasketballLeagueTracker.Infrastructure.Migrations
{
    [DbContext(typeof(BasketballLeagueTrackerDbContext))]
    partial class BasketballLeagueTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("ApplicationUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WantsToHaveNotification")
                        .HasColumnType("bit");

                    b.HasKey("ApplicationUserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticleId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("UserApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArticleId");

                    b.HasIndex("LeagueId");

                    b.HasIndex("UserApplicationUserId");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.ArticleImage", b =>
                {
                    b.Property<int>("ArticleImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticleImageId"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ArticleImageId");

                    b.HasIndex("ArticleId");

                    b.ToTable("ArticleImage");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.League", b =>
                {
                    b.Property<int>("LeagueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeagueId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeaugeMVPPlayerId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Logo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Season")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LeagueId");

                    b.HasIndex("LeaugeMVPPlayerId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GamesPlayed")
                        .HasColumnType("int");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<bool?>("IsInTeam")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<int?>("UniformNumber")
                        .HasColumnType("int");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.SeasonStatistics", b =>
                {
                    b.Property<int>("SeasonStatisticsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeasonStatisticsId"));

                    b.Property<int>("GamesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<int>("LeaguePoints")
                        .HasColumnType("int");

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<double>("OpponentPointsPerGame")
                        .HasColumnType("float");

                    b.Property<double>("PointsPerGame")
                        .HasColumnType("float");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("SeasonStatisticsId");

                    b.HasIndex("LeagueId");

                    b.HasIndex("TeamId");

                    b.ToTable("SeasonStatistics");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.Stadium", b =>
                {
                    b.Property<int>("StadiumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StadiumId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StadiumId");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCurrentlyPlaying")
                        .HasColumnType("bit");

                    b.Property<int?>("LeagueId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StadiumId")
                        .HasColumnType("int");

                    b.Property<byte[]>("TeamLogo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("TeamId");

                    b.HasIndex("LeagueId");

                    b.HasIndex("StadiumId")
                        .IsUnique()
                        .HasFilter("[StadiumId] IS NOT NULL");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.Article", b =>
                {
                    b.HasOne("BasketballLeagueTracker.Domain.Entities.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasketballLeagueTracker.Domain.Entities.ApplicationUser", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserApplicationUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("League");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.ArticleImage", b =>
                {
                    b.HasOne("BasketballLeagueTracker.Domain.Entities.Article", "Article")
                        .WithMany("Images")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.League", b =>
                {
                    b.HasOne("BasketballLeagueTracker.Domain.Entities.Player", "LeaugeMVP")
                        .WithMany()
                        .HasForeignKey("LeaugeMVPPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeaugeMVP");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.Player", b =>
                {
                    b.HasOne("BasketballLeagueTracker.Domain.Entities.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Team");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.SeasonStatistics", b =>
                {
                    b.HasOne("BasketballLeagueTracker.Domain.Entities.League", "League")
                        .WithMany("SeasonStatistics")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BasketballLeagueTracker.Domain.Entities.Team", "Team")
                        .WithMany("SeasonStatistics")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("League");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.Team", b =>
                {
                    b.HasOne("BasketballLeagueTracker.Domain.Entities.League", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("BasketballLeagueTracker.Domain.Entities.Stadium", "Stadium")
                        .WithOne("Team")
                        .HasForeignKey("BasketballLeagueTracker.Domain.Entities.Team", "StadiumId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("League");

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.Article", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.League", b =>
                {
                    b.Navigation("SeasonStatistics");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.Stadium", b =>
                {
                    b.Navigation("Team")
                        .IsRequired();
                });

            modelBuilder.Entity("BasketballLeagueTracker.Domain.Entities.Team", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("SeasonStatistics");
                });
#pragma warning restore 612, 618
        }
    }
}
