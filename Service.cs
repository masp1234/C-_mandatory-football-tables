using FootBall.File;
using Football_tables.enums;
using Football_tables.models;

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
            /*
            var rounds = fileHandler.ReadRounds();
            leagues = DivideIntoFractions(leagues);
            foreach (var round in rounds)
            {
                if (round.Number == 23)
                {
                    leagues = DivideIntoFractions(leagues);
                }
                foreach (var match in round.Matches)   
                {
                    
                    League league = leagues[match.League];
                    if (round.Number < 23)
                    {
                        
                        (Team? homeTeam, Team? awayTeam) = findTeams(match, league.Teams);
                        if (IsRelevantMatch(league, match) && !HasAlreadyPlayed(match, homeTeam, awayTeam, round))
                        {

                            ProcessMatch(match, homeTeam.Result, awayTeam.Result);
                        }
                    }
                    else
                    {

                    }        
                }
                foreach (var key in leagues.Keys)
                {
                    View.PrintCurrentStanding(leagues[key].Teams);
                    Console.WriteLine();
                }
            
        }
         */   
        }

        private Dictionary<string, League> DivideIntoFractions(Dictionary<string, League> leagues)
        {
            foreach (var league in leagues.Values)
            {   // skal måske lige ændres - kommer an på om range er inklusiv eller eklusiv.
                ClearMatchHistory(league.Teams);
                league.UpperFraction = league.Teams.ToArray()[..(league.Teams.Count / 2)];
                league.LowerFraction = league.Teams.ToArray()[(league.Teams.Count / 2)..];
            }
            return leagues;
        }
        private void ClearMatchHistory(List<Team> teams)
        {
            teams.ForEach(team => team.ClearHomeMatchesAgainst());
        }

        private void ProcessMatch(GameMatch match, Result homeTeamResult, Result awayTeamResult)
        {
            

            homeTeamResult.GoalsAgainst += match.AwayGoals;
            awayTeamResult.GoalsAgainst += match.HomeGoals;

            homeTeamResult.GoalsFor += match.HomeGoals;
            awayTeamResult.GoalsFor += match.AwayGoals;


            if (match.AwayGoals == match.HomeGoals)
            {
                homeTeamResult.GamesDrawn += 1;
                awayTeamResult.GamesDrawn += 1;

                homeTeamResult.addMatchResult(MatchResult.D);
                awayTeamResult.addMatchResult(MatchResult.D);
            }
            else if (match.HomeGoals > match.AwayGoals)
            {
                homeTeamResult.GamesWon += 1;
                awayTeamResult.GamesLost += 1;

                homeTeamResult.addMatchResult(MatchResult.W);
                awayTeamResult.addMatchResult(MatchResult.L);
            }
            else
            {
                awayTeamResult.GamesWon += 1;
                homeTeamResult.GamesLost += 1;

                homeTeamResult.addMatchResult(MatchResult.L);
                awayTeamResult.addMatchResult(MatchResult.W);
            }

        }

        private bool HasAlreadyPlayed(GameMatch match, Team? homeTeam, Team? awayTeam, Round round)
        {

            foreach (string homeMatchAgainst in homeTeam.HomeMatchesAgainst)
            {
                if (homeMatchAgainst == awayTeam.Abbreviation)
                {
                    throw new InvalidDataException($"{match.Home} has already played against {match.Away}. " +
                                                    $"The error is in round: {round.Number}");
                }
            }
            homeTeam.AddHomeMatchesAgainst(match.Away);
            return false;
        }

        private (Team?,Team?) findTeams(GameMatch match, List<Team> teams)
        {
            Team? homeTeam = null;
            Team? awayTeam = null;

            foreach(Team team in teams)
            {
                if(homeTeam != null && awayTeam != null)
                {
                    break;
                }else if(match.Home == team.Abbreviation)
                {
                    homeTeam = team;
                }else if(match.Away == team.Abbreviation)
                {
                    awayTeam = team;
                }
            }
            return (homeTeam, awayTeam);
        }

        private bool IsRelevantMatch(League league, GameMatch match)
        {
                if (league.LeagueInfo.Name == match.League)
                {
                    return true;       
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
                        league.Add(teams[i]);
                        teams.RemoveAt(i);
                        i--;
                    }
                }
                leagueDictionary.Add(league.LeagueInfo.Name, league);
            }
            return leagueDictionary;
        }
	}
}

