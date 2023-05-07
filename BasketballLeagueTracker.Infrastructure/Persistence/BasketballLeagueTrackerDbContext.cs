using BasketballLeagueTracker.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballLeagueTracker.Infrastructure.Persistence
{
    public class BasketballLeagueTrackerDbContext :IdentityDbContext
    {


        public BasketballLeagueTrackerDbContext(DbContextOptions<BasketballLeagueTrackerDbContext> options) : base(options) 
        {

        }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<SeasonStatistics> SeasonStatistics { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleImage> ArticaleImages { get; set; }

        public DbSet<FavouritePlayer> FavouritePlayers { get; set; }
        public DbSet<FavouriteTeam> FavouriteTeams { get; set; }

        //public DbSet<Comment> Comments { get; set; }
        //public DbSet<Game> Games { get; set; }
        //public DbSet<GamePlayerStats> GamePlayerStats { get; set; }
        //public DbSet<UserCommentRating> UserCommentRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Jedna liga ma wiele zespołów
            modelBuilder.Entity<League>()
                .HasMany(l => l.Teams)
                .WithOne(t => t.League)
                .OnDelete(DeleteBehavior.NoAction);
            // Jedna drużyna ma wielu zawodników
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .OnDelete(DeleteBehavior.NoAction);
            // Jedna drużyna ma jeden stadion
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Stadium)
                .WithOne(s => s.Team)
                .OnDelete(DeleteBehavior.NoAction);
            // Jedna drużyna ma wiele statystyk sezonu
            modelBuilder.Entity<SeasonStatistics>()
                .HasOne(ss => ss.Team)
                .WithMany(t => t.SeasonStatistics)
                .OnDelete(DeleteBehavior.NoAction);
            // Jedna liga ma wiele statystyk 
            modelBuilder.Entity<SeasonStatistics>()
                .HasOne(ss => ss.League)
                .WithMany(l => l.SeasonStatistics)
                .OnDelete(DeleteBehavior.NoAction);
            // Jeden użytkownik mopże posiadać wiele artykułów
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(au => au.Articles)
                .WithOne(a => a.User)
                .OnDelete(DeleteBehavior.NoAction);
            // Jeden artykuł może posaidać wiele zdjęć, jedno zdjęcie przypisane jest do danego artykułu
            modelBuilder.Entity<Article>()
                .HasMany(a => a.Images)
                .WithOne(i => i.Article)
                .OnDelete(DeleteBehavior.NoAction);

            // Jedena pozycja ulubionego zawodnika posiada jedno odwołanie do zawodnika, jeden zawodnik może być ulubionym zawodnikiem wielu użytkowników
            modelBuilder.Entity<FavouritePlayer>()
                .HasOne(fp => fp.Player)
                .WithMany(p => p.FavouritePlayers)
                .OnDelete(DeleteBehavior.NoAction);

            // Jedena pozycja ulubionego zawodnika posiada jedno odwołanie do użytkownika, użytkownik może mieć wiele ulubionych zawodników
            modelBuilder.Entity<FavouritePlayer>()
                 .HasOne(fp => fp.User)
                 .WithMany(u => u.FavouritePlayers)
                 .OnDelete(DeleteBehavior.Cascade);

            // Jedna pozycja ulubionej drużyny posiada jedno odwołanie do drużyny, drużyna może być ulubioną drużyną wielu użytkowników
            modelBuilder.Entity<FavouriteTeam>()
                .HasOne(ft => ft.Team)
                .WithMany(t => t.FavouriteTeams)
                .OnDelete(DeleteBehavior.NoAction);
            // Jedena pozycja ulubionej drużyny posiada jedno odwołanie do drużyny, użytkownik może mieć wiele ulubionych drużyn
            modelBuilder.Entity<FavouriteTeam>()
                .HasOne(ft => ft.User)
                .WithMany(u => u.FavouriteTeams)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
