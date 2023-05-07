using BasketballLeagueTracker.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballLeagueTracker.Infrastructure.Seeders
{
    public class TeamSeeder
    {
        private readonly BasketballLeagueTrackerDbContext _dbContext;

        public TeamSeeder(BasketballLeagueTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Teams.Any())
                {
                    var teamToSeed = new Domain.Entities.Team()
                    {
                        Name = "Team Steam",
                        Description = "Best Team in the world.",
                        IsCurrentlyPlaying = false,
                        TeamLogo= new byte[] { 0x12, 0xAB, 0xCD }

                };
                    
                    _dbContext.Teams.Add(teamToSeed);
                    await _dbContext.SaveChangesAsync();
                }

            }
        }
    }
}
