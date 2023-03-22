using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_tables
{
    internal class Round
    {
        public String Home { get; set; }
        public String Away { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }

        public Round(string home, string away, int homeGoals, int awayGoals)
        {
            this.Home = home;
            this.Away = away;
            this.HomeGoals = homeGoals;
            this.AwayGoals = awayGoals;
    }
    }
    
}
