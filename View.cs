using System;
using Football_tables.models;
namespace Football_tables
{
	public class View
	{
        public static void PrintCurrentStanding(List<Result> results)
        {
            results.Sort();
            foreach(Result result in results)
            {
                //resten af attributes og colors
                Console.WriteLine($"{result.Postion}. {result.SpecialMarking} {result.FullClubName} ");
            }
        }
    }
}

