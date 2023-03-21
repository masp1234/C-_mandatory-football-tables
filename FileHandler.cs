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

        public List<Team> readFile()
        {
            List<Team> teams = new();

            string filePath = "C:\\Users\\Martin\\4. Semester\\C# - Unity\\mandatories\\Football-tables\\test.csv";
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
                teams.Add(team);
            }

            Console.WriteLine(teams.Count());

            return teams;
        }

       
        
        
        //string text = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");
    }
}
