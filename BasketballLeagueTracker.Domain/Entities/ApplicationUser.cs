using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballLeagueTracker.Domain.Entities
{
    public class ApplicationUser
    {
        [Key]
        public Guid ApplicationUserId { get; set; }

        public string Username { get; set; } 
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool WantsToHaveNotification { get; set; }

        public ICollection<Article>? Articles { get; set; }

    }
        //public ICollection<FavouritePlayer> FavouritePlayers { get; set; }
        //public ICollection<FavouriteTeam> FavouriteTeams { get; set; }
        //public ICollection<Comment> Comments { get; set; }
}
