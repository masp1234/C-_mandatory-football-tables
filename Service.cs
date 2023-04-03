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

        }
	}
}

