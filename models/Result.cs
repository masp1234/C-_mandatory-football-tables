using System;
using Football_tables.enums;
namespace Football_tables.models
{
	internal class Result
	{
        public List<MatchResult> MatchResults { get; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int GamesDrawn { get; set; }
        public int GamesLost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }

        public Result() {
            MatchResults = new List<MatchResult>();
        }
        


        //Lav en comparator der skal sorteres efter de 5 ting som opgaven nævner
	}
}

