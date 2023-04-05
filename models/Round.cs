namespace Football_tables.models
{
    internal class Round
    {
        public int Number { get; set; }
        public List<GameMatch> Matches { get; set; }

        public Round(int number)
        {
            Number = number;
            Matches = new List<GameMatch>();
        }

        public void AddMatch(GameMatch match)
        {
            Matches.Add(match);
        }
    }
}
