using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace GendacHashProduct.Models
{
    public class TeamViewModel
    {
        public List<NBAPlayer> AllNBAPlayers { get; set; }
        public SelectList AllTeams { get; set; }
        public string PlayerTeam { get; set; }
        public string SearchString { get; set; }

    }
}
