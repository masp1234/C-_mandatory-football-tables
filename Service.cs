﻿using FootBall.File;
using Football_tables.enums;
using Football_tables.models;
using System.Text.RegularExpressions;

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
            int splitIntoFractionsRound = 15;
            var leagues = GetLeagues();
            var rounds = fileHandler.ReadRounds();

            foreach (var round in rounds)
            {
                if (round.Number == splitIntoFractionsRound)
                {
                    leagues = DivideIntoFractions(leagues);
                }
                foreach (var match in round.Matches)   
                {    
                    League league = leagues[match.League];
                    if (round.Number < splitIntoFractionsRound)
                    {    
                        (Team? homeTeam, Team? awayTeam) = FindTeams(match, league.Teams);

                        if (homeTeam is not null && awayTeam is not null)
                        {
                            if (IsRelevantMatch(league, match) && !HasAlreadyPlayed(match, homeTeam, awayTeam, round))
                            {

                                ProcessMatch(match, homeTeam.Result, awayTeam.Result);
                            }
                        }       
                    }
                    else
                    {
                        (Team? homeTeam, Team? awayTeam) = FindTeams(match, league.UpperFraction.ToList(), league.LowerFraction.ToList());

                        if (homeTeam is not null && awayTeam is not null)
                        {
                            if (IsRelevantMatch(league, match) && !HasAlreadyPlayed(match, homeTeam, awayTeam, round))
                            {
                                ProcessMatch(match, homeTeam.Result, awayTeam.Result);
                            }
                        }
                    }        
                }
                if (round.Number < splitIntoFractionsRound)
                foreach (League league in leagues.Values)
                {
                    View.PrintCurrentStanding(league.Teams, league.LeagueInfo);
               
                }
                if (round.Number >= splitIntoFractionsRound)
                    foreach (League league in leagues.Values)
                    {
                        View.PrintCurrentStanding(league.UpperFraction.ToList(), league.LeagueInfo, "Upper Fraction");
                        
                        View.PrintCurrentStanding(league.LowerFraction.ToList(), league.LeagueInfo, "Lower Fraction");
                    }

            }
            
        }

        private Dictionary<string, League> DivideIntoFractions(Dictionary<string, League> leagues)
        {
            foreach (var league in leagues.Values)
            {
                ClearMatchHistory(league.Teams);
                List<Team> teams = League.SortList(league.Teams);
                league.UpperFraction = teams.ToArray()[..(teams.Count / 2)];
                league.LowerFraction = teams.ToArray()[(teams.Count / 2)..];
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
                    Console.WriteLine($"{match.Home} as home team has already played against {match.Away} as away team. " +
                                                    $"The error is in round: {round.Number}");
                }
            }
            homeTeam.AddHomeMatchesAgainst(match.Away);
            return false;
        }

        private (Team?,Team?) FindTeams(GameMatch match, List<Team> teams, List<Team>? lowerFraction = null)
        {
            Team? homeTeam = null;
            Team? awayTeam = null;

            SetTeams(teams, match, ref homeTeam, ref awayTeam);

            if (lowerFraction is not null && homeTeam is not null && awayTeam is not null)
            {
                SetTeams(lowerFraction, match, ref homeTeam, ref awayTeam);
            }

            return (homeTeam, awayTeam);
        }
        private void SetTeams(List<Team> teams, GameMatch match, ref Team homeTeam, ref Team awayTeam)
        {
            
            foreach (Team team in teams)
            {
                if (homeTeam is not null && awayTeam is not null)
                {
                    return;
                }
                else if (match.Home == team.Abbreviation)
                {
                    homeTeam = team;
                    
                }
                else if (match.Away == team.Abbreviation)
                {
                    awayTeam = team;
                }

            }
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
                    string teamName = teams[i].LeagueName;
                    string leagueName = league.LeagueInfo.Name;
                   
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

