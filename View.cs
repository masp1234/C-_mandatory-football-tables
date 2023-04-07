using Football_tables.models;
namespace Football_tables
{
    internal class View
	{
        public static void PrintCurrentStanding(List<Team> teams)
        {
            var currentStanding = League.SortList(teams);
            foreach (var team in currentStanding)
            {
                Console.WriteLine(team);
            }
        }
    }
}

