using BasketballLeagueTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballLeagueTracker.Infrastructure.Persistence
{
    public class BasketballLeagueTrackerDbContext :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\repos\\BasketballLeagueTracker\\BasketballLeagueTracker.Infrastructure\\Persistence\\BasketDb.mdf;Integrated Security=True");
        }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<SeasonStatistics> SeasonStatistics { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            //base.OnModelCreating(modelBuilder);
        }
    }
}
