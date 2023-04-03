using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Football_tables;
using Football_tables.models;

namespace FootBall.File
{


    internal class FileHandler
    {

        public List<Team> ReadTeams()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
        
            List<Team> teams = new();

            string filePath = basePath[..^17] + "files/teams/teams.csv";
                //"C:\\Users\\Martin\\4. Semester\\C# - Unity\\mandatories\\Football-tables\\files\\teams\\teams.csv";
            StreamReader reader = null;

            if (System.IO.File.Exists(filePath))
            {
                reader = new StreamReader(System.IO.File.OpenRead(filePath));
            }
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                Team team = new Team(values[0], values[1], values[2]);
                Console.WriteLine(string.Join(' ', values));
                teams.Add(team);
            }

            Console.WriteLine(teams.Count());

            return teams;
        }
        
        public List<League> ReadLeagues()
        {
            List<League> leagues = new();

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = basePath[..^17] + "files/setup/setup.csv";
            StreamReader reader = null;

            if (System.IO.File.Exists(filePath))
            {
                reader = new StreamReader(System.IO.File.OpenRead(filePath));
            }
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                string leagueName = values[0];
                int positionsPromotedToChampionsLeague;
                int positionsPromotedToEuropaLeague;
                int positionsPromotedToConferenceLeague;
                int positionsPromotedToUpperLeague;
                int positionsRelegatedToLowerLeague;
              
                bool positionsPromotedToChampionsLeagueIsValid = int.TryParse(values[1], out positionsPromotedToChampionsLeague);
                bool positionsPromotedToEuropaLeagueIsValid = int.TryParse(values[2], out positionsPromotedToEuropaLeague);
                bool positionsPromotedToConferenceLeagueIsValid = int.TryParse(values[3], out positionsPromotedToConferenceLeague);
                bool positionsPromotedToUpperLeagueIsValid = int.TryParse(values[4], out positionsPromotedToUpperLeague);
                bool positionsRelegatedToLowerLeagueIsValid = int.TryParse(values[5], out positionsRelegatedToLowerLeague);

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
                
                
                // smid leagues listen videre til readrounds, så der kun læses matches, som indgår i listen.
            }
            Console.WriteLine(string.Join(' ', leagues));
            return leagues;
        }
        

        public List<Round> ReadRounds()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string[] files = Directory.GetFiles(basePath[..^17] + "files/rounds");
            List<Round> rounds = new();

            
           
            foreach(string file in files)
            {
                Regex regex = new Regex(@"\\round-(\d+)");
                var regexMatch = regex.Match(file);

                string fileName = regexMatch.Value[1..];
                // TODO split matches[0] og tag sidste del - sæt resultat til round.Number
                Round round = new Round(1);
                // hent alle filer i en mappe
                // for hver fil i mappe, læs runde
                StreamReader reader = new StreamReader(System.IO.File.OpenRead(file));
                // for at skippe første linje med headers
                reader.ReadLine();
                
                int lineNumber = 2;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    int homeGoals;
                    int awayGoals;
                    bool homeGoalsIsValid = int.TryParse(values[3], out homeGoals);
                    bool awayGoalsIsValid = int.TryParse(values[4], out awayGoals);
                    if (homeGoalsIsValid && awayGoalsIsValid)
                    {
                        var match = new Football_tables.models.Match(values[0], values[1], values[3], homeGoals, awayGoals);
                        Console.WriteLine(string.Join(' ', values));
                        round.AddMatch(match);
                    }
                    else
                    {
                        throw new InvalidDataException($"Invalid input was found in file: {fileName} on line: {lineNumber}");
                    }
                    lineNumber += 1;
                }
                rounds.Add(round);
            }
            Console.WriteLine(string.Join(' ', files));
            
            return rounds;
           

        }
    }
}
