using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football_tables;

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

        public List<Round> ReadRounds(int roundNumber)
        {
            List<Round> rounds = new();
            // hent alle filer i en mappe
            // for hver fil i mappe, læs runde

            string filePath = $"C:\\Users\\Martin\\4. Semester\\C# - Unity\\mandatories\\Football-tables\\round-{roundNumber}.csv";
            StreamReader reader = null;

            if (System.IO.File.Exists(filePath))
            {
                reader = new StreamReader(System.IO.File.OpenRead(filePath));
                string headerLine = reader.ReadLine();
            }
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
                    Round round = new Round(values[0], values[1], homeGoals, awayGoals);
                    Console.WriteLine(string.Join(' ', values));
                    rounds.Add(round);
                }
                else
                {
                    throw new InvalidDataException($"An invalid input was found in <filename> on {lineNumber}");
                }
                lineNumber += 1;
                
            }
            return rounds;

        }

       
        
        
        //string text = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");
    }
}
