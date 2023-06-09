﻿using System.Text.RegularExpressions;
using Football_tables.models;

namespace FootBall.File
{
    internal class FileHandler
    {
        public List<Team> ReadTeams()
        {
            List<Team> teams = new();
            StreamReader? reader = GetReader("files/teams/teams.csv");

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                Team team = new Team(values[0], values[1], values[2], values[3].ToLower());
                teams.Add(team);
            }
            return teams;
        }

        private StreamReader GetReader(string path)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = basePath[..^17] + path;

            StreamReader? reader;

            if (System.IO.File.Exists(filePath))
            {
                reader = new StreamReader(System.IO.File.OpenRead(filePath));
            }
            else
            {
                throw new FileNotFoundException($"Could not find file on path: ${filePath}");
            }
            return reader;

        }
        public List<League> ReadLeagues()
        {
            List<League> leagues = new();


            StreamReader reader = GetReader("files/setup/setup.csv");
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                string leagueName = values[0].ToLower();
                bool positionsPromotedToChampionsLeagueIsValid = int.TryParse(values[1], out int positionsPromotedToChampionsLeague);
                bool positionsPromotedToEuropaLeagueIsValid = int.TryParse(values[2], out int positionsPromotedToEuropaLeague);
                bool positionsPromotedToConferenceLeagueIsValid = int.TryParse(values[3], out int positionsPromotedToConferenceLeague);
                bool positionsPromotedToUpperLeagueIsValid = int.TryParse(values[4], out int positionsPromotedToUpperLeague);
                bool positionsRelegatedToLowerLeagueIsValid = int.TryParse(values[5], out int positionsRelegatedToLowerLeague);

                if (positionsPromotedToChampionsLeagueIsValid &&
                    positionsPromotedToEuropaLeagueIsValid &&
                    positionsPromotedToConferenceLeagueIsValid &&
                    positionsPromotedToUpperLeagueIsValid &&
                    positionsRelegatedToLowerLeagueIsValid)
                {
                    League league = new()
                    {
                        LeagueInfo = new LeagueInfo(
                        leagueName,
                        positionsPromotedToChampionsLeague,
                        positionsPromotedToEuropaLeague,
                        positionsPromotedToConferenceLeague,
                        positionsPromotedToUpperLeague,
                        positionsRelegatedToLowerLeague
                        )
                    };
                    leagues.Add(league);
                }
            }
            return leagues;
        }


        public List<Round> ReadRounds()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string[] files = Directory.GetFiles(basePath[..^17] + "files/rounds");
            List<Round> rounds = new();

            foreach (string file in files)
            {
                Regex regex = new Regex(@"\\round-(\d+)");
                var regexMatch = regex.Match(file);

                string fileName = regexMatch.Value[1..];
                string[] strings = fileName.Split("-");
                int roundNumber = int.Parse(strings[1]);

                Round round = new Round(roundNumber);
                StreamReader reader = new StreamReader(System.IO.File.OpenRead(file));

                reader.ReadLine();

                int lineNumber = 2;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    if (IsTeamPlayingAgainstItself(values))
                    {
                        throw new InvalidDataException($"{values[1]} is playing against {values[2]}." +
                            $" A team playing against itself is not allowed. The error is happening in file: {fileName} on line: {lineNumber}");
                    }

                    GameMatch? match = CreateGameMatch(values);
                    if (match == null)
                    {
                        throw new InvalidDataException($"The match in file: {fileName} has invalid data on line: {lineNumber}");
                    }
                    round.AddMatch(match);
                    lineNumber += 1;
                }
                rounds.Add(round);
            }
            return rounds;


        }
        private bool IsTeamPlayingAgainstItself(string[] values)
        {
            return values[1] == values[2];
        } 
        private GameMatch? CreateGameMatch(string[] values)
        {
            GameMatch? match = null;

            string leagueName = values[0].ToLower();
            string homeTeam = values[1];
            string awayTeam = values[2];
            bool homeGoalsIsValid = int.TryParse(values[3], out int homeGoals);
            bool awayGoalsIsValid = int.TryParse(values[4], out int awayGoals);
            if (homeGoalsIsValid && awayGoalsIsValid)
            {
                match = new GameMatch(leagueName, homeTeam, awayTeam, homeGoals, awayGoals);    
            }
            return match;
            
        }
    }
}
