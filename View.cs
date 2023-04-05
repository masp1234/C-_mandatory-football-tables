using Football_tables.models;
namespace Football_tables
{
    internal class View
	{
        public static void PrintCurrentStanding(List<Team> teams)
        {
            Console.WriteLine(League.SortList(teams));
        }
    }
}

