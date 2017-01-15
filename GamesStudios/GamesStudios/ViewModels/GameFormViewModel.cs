using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamesStudios.Models;

namespace GamesStudios.ViewModels
{
    public class GameFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Game Game { get; set; }
    }
}