using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballLeagueTracker.Domain.Entities
{
    public class ArticleImage
    {
        public int ArticleImageId { get; set; }

        public string? FileName { get; set; }
        public byte[] ImageData { get; set; }

        public Article Article { get; set; }
    }

}
