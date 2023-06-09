﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballLeagueTracker.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Data założenia")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Display(Name ="Powiadomienia")]
        public bool? WantsToHaveNotification { get; set; }

        public ICollection<Article>? Articles { get; set; }
        [Display(Name ="Ulubioni zawodnicy ")]
        public ICollection<FavouritePlayer> FavouritePlayers { get; set; }
        [Display(Name ="Ulubione drużyny ")]
        public ICollection<FavouriteTeam> FavouriteTeams { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<UserCommentRating> UserCommentRaitings { get; set; }
    }

    //[Key]
    //public Guid ApplicationUserId { get; set; }

    //public string Username { get; set; } 
    //public string Password { get; set; }

}
