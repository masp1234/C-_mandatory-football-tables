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
			List<League> leagues = fileHandler.ReadLeagues();
			List<Team> teams = fileHandler.ReadTeams();

			foreach (League league in leagues)
			{
				for (int i = 0;  i < teams.Count; i++)
				{
					
                    if (league.LeagueInfo.Name == teams[i].LeagueName)
                    {
                        Console.WriteLine(teams[i].FullName);
                        league.Add(teams[i]);
						teams.RemoveAt(i);
						i--;
                    }
                    
                }
                Console.WriteLine(league.Teams.Count);
            }


        }
	}
}

