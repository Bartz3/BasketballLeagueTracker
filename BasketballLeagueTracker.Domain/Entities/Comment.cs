using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballLeagueTracker.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime DateAdded { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<UserCommentRating> Ratings { get; set; }
    }
}
