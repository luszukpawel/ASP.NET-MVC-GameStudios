using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesStudios.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string DownloadLink { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }

    }
}