using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_tables.models
{
    internal class League
    {
        public LeagueInfo LeagueInfo { get; set; }
        public List<Team> Teams { get; }

        public List<Team>? UpperFraction { get; set; }

        public List<Team>? LowerFraction { get; set; }

        public League() {
            Teams = new List<Team>();
        }
        public void Add(Team team) 
        { 
            Teams.Add(team); 
        }

        public override string ToString()
        {
            return $"League info: {this.LeagueInfo}";
        }
    }
}
