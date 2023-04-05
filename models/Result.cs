using System;
using Football_tables.enums;
namespace Football_tables.models
{
    internal class Result
    {
        public List<MatchResult> MatchResults { get; }
        public int GamesPlayed { get => MatchResults.Count; }
        public int GamesWon { get; set; }
        public int GamesDrawn { get; set; }
        public int GamesLost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get => GoalsFor - GoalsAgainst; }
        public int Points { get => ((GamesDrawn * 1) + (GamesWon * 3)); }

        public Result() {
            MatchResults = new List<MatchResult>();
        }

        public void addMatchResult(MatchResult matchResult)
        {
            MatchResults.Add(matchResult);
        }


        //Lav en comparator der skal sorteres efter de 5 ting som opgaven nævner
	}
}

