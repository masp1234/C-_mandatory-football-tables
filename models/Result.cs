using System;
namespace Football_tables.models
{
	public class Result
	{
		public int Postion { get; set; }
        public string SpecialMarking { get; set; }
        public string FullClubName { get; set; }
        // TODO fjern de 4 nedenstående Properties og lav istedet en liste med Enums: WIN, LOSS, DRAW
        // gamesplayed er jo bare listens længde
        
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int GamesDrawn { get; set; }
        public int GamesLost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }
        public string Streak { get; set; }

        public Result(int position, string specialMarking, string fullClubName,int gamesPlayed,int gamesWon, int gamesDrawn,
            int gamesLost,int goalsFor, int goalsAgainst,int goalDifference,int points,string streak)
		{
            this.Postion = position;
            this.SpecialMarking = specialMarking;
            this.FullClubName = fullClubName;
            this.GamesPlayed = gamesPlayed;
            this.GamesWon = gamesWon;
            this.GamesDrawn = gamesDrawn;
            this.GamesLost = gamesLost;
            this.GoalsFor = goalsFor;
            this.GoalsAgainst = goalsAgainst;
            this.GoalDifference = goalDifference;
            this.Points = points;
            this.Streak = streak;

		}


        //Lav en comparator der skal sorteres efter de 5 ting som opgaven nævner
	}
}

