using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Football_tables;
using Football_tables.Models;

namespace FootBall.File
{
    internal class FileHandler
    {

        public List<Team> ReadTeams()
        {
            List<Team> teams = new();

            string filePath = "C:\\Users\\Martin\\4. Semester\\C# - Unity\\mandatories\\Football-tables\\teams.csv";
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

        public List<Round> ReadRounds()
        {
            string[] files = Directory.GetFiles($"C:\\Users\\Martin\\4. Semester\\C# - Unity\\mandatories\\Football-tables\\rounds");
            List<Round> rounds = new();

            foreach(string file in files)
            {
                Regex regex = new Regex(@"\\round-(\d+)");
                MatchCollection matches = regex.Matches(file);
                // TODO split matches[0] og tag sidste del - sæt resultat til round.Number
                Console.WriteLine(string.Join(' ', matches));
                Round round = new Round(1);
                // hent alle filer i en mappe
                // for hver fil i mappe, læs runde
                StreamReader reader = new StreamReader(System.IO.File.OpenRead(file));
                string headerLine = reader.ReadLine();
                
                int lineNumber = 2;

                
                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    int homeGoals;
                    int awayGoals;
                    bool homeGoalsIsValid = int.TryParse(values[2], out homeGoals);
                    bool awayGoalsIsValid = int.TryParse(values[3], out awayGoals);
                    if (homeGoalsIsValid && awayGoalsIsValid )
                    {
                        var match = new Football_tables.Models.Match(values[0], values[1], homeGoals, awayGoals);
                        Console.WriteLine(string.Join(' ', values));
                        round.AddMatch(match);
                    }
                    else
                    {
                        throw new InvalidDataException($"An invalid input was found in <filename> on {lineNumber}");
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
