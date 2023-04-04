using FootBall.File;
using Football_tables.models;
using System;

namespace Football_tables
{
	internal class Service
	{
		private FileHandler fileHandler;
		public Service()
		{
			this.fileHandler = new();
		}

		public void Run()
		{
            var leagues = GetLeagues();
            var rounds = fileHandler.ReadRounds();
            foreach (var round in rounds)
            {
                foreach (var match in round.Matches)
                {
                    if (IsRelevantMatch(leagues, match)) {
                        var homeTeam = 
                        if(!HasAlreadyPlayed(match))
                        {

                        }

                    }
                    

                }
                

            }
        }

       
        private bool IsRelevantMatch(List<League> leagues, Match match)
        {
            foreach (var league in leagues)
            {
                if (league.LeagueInfo.Name == match.League)
                {
                    return true;
                }
            }
            return false;
        }
		public Dictionary<string, League> GetLeagues() {
            Dictionary<string, League> leagueDictionary = new();

            List<League> leagues = fileHandler.ReadLeagues();
            List<Team> teams = fileHandler.ReadTeams();

            foreach (League league in leagues)
            {
                for (int i = 0; i < teams.Count; i++)
                {
                    if (league.LeagueInfo.Name == teams[i].LeagueName)
                    {
                        Console.WriteLine(teams[i].FullName);
                        league.Add(teams[i]);
                        teams.RemoveAt(i);
                        i--;
                    }
                }
                leagueDictionary.Add(league.LeagueInfo.Name, league);
                Console.WriteLine(league.Teams.Count);
            }
            return leagueDictionary;
        }
	}
}

