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
        public static List<Team> sortList(List<Team> teams)
        {
            return teams.OrderByDescending(team => team.Result.Points)
                .ThenByDescending(team => team.Result.GoalDifference)
                .ThenByDescending(team => team.Result.GoalsFor)
                .ThenByDescending(team => team.Result.GoalsAgainst)
                .ThenBy(team => team.FullName)
                .ToList();
        }
    }
}
