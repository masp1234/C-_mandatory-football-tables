namespace Football_tables.models
{
    internal class GameMatch
    {
        public String League { get; set; }
        public String Home { get; set; }
        public String Away { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }

        public GameMatch(string league, string home, string away, int homeGoals, int awayGoals)
        {
            this.League = league;
            this.Home = home;
            this.Away = away;
            this.HomeGoals = homeGoals;
            this.AwayGoals = awayGoals;
    }
    }
    
}
