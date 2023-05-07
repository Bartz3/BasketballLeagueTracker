using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballLeagueTracker.Domain.Entities
{
    public class UserCommentRating
    {
        public int UserCommentRatingId { get; set; }

        public bool Rating { get; set; }
        public DateTime DateAdded { get; set; }

        //public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
