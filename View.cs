using Football_tables.enums;
using Football_tables.models;
namespace Football_tables
{
    internal class View
	{
        public static void PrintCurrentStanding(List<Team> teams, LeagueInfo leagueInfo, string? fraction = null)
        {
            Console.ResetColor();
            var currentStanding = League.SortList(teams);
            int positionCounter = 0;
            Console.WriteLine($"{leagueInfo.Name.ToUpper()} {(fraction ?? "")}");
            Console.WriteLine("Pos  Team   M W D L GF GA GD P Streak");

            Team previousTeam = null;
            foreach (var team in currentStanding)
            {
                ChangeColor(leagueInfo, positionCounter, fraction, teams.Count);
                Console.WriteLine(
                    $"{(HasSamePosition(previousTeam, team) ? "-" : positionCounter += 1)} " +
                    $"{(team.SpecialRanking == "" ? "" : "(" + team.SpecialRanking + ")")} " +
                    $"{team.FullName} ({team.Abbreviation}) {team.Result.GamesPlayed} {team.Result.GamesWon} " +
                    $"{team.Result.GamesDrawn} {team.Result.GamesLost} {team.Result.GoalsFor} {team.Result.GoalsAgainst} " +
                    $"{team.Result.GoalDifference} {team.Result.Points} {FormatStreak(team.Result.MatchResults)}"
                    );
                previousTeam = team;
            }
            Console.ResetColor();
            Console.WriteLine();
        }
        private static string FormatStreak(List<MatchResult> matchResults)
        {
            if (matchResults.Count == 0)
            {
                return "0";
            }
            int streakCounter = 1;
            MatchResult currentStreak = matchResults[matchResults.Count - 1];
            for (int i = matchResults.Count - 2; 0 < i; i--)
            {
                if (currentStreak == matchResults[i])
                {
                    streakCounter++;
                }
                else
                {
                    return streakCounter.ToString() + currentStreak.ToString();
                }
            }
            return streakCounter.ToString() + currentStreak.ToString();

        }
        private static bool HasSamePosition(Team previousTeam, Team currentTeam)
        {
            if (previousTeam == null)
            {
                return false;
            }
            return previousTeam.Result.Points == currentTeam.Result.Points &&
                   previousTeam.Result.GoalDifference == currentTeam.Result.GoalDifference &&
                   previousTeam.Result.GoalsFor == currentTeam.Result.GoalsFor &&
                   previousTeam.Result.GoalsAgainst == currentTeam.Result.GoalsAgainst &&
                   previousTeam.Result.GamesPlayed == currentTeam.Result.GamesPlayed;
        }
        private static void ChangeColor(LeagueInfo leagueInfo, int position, string fraction, int teamLength)
        {
            if (fraction == null)
            {
                if (leagueInfo.PositionsPromotedToChampionsLeague +
                    leagueInfo.PositionsPromotedToConferenceLeague +
                    leagueInfo.PositionsPromotedToEuropaLeague +
                    leagueInfo.PositionsPromotedToUpperLeague >
                    position)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (position >= teamLength - leagueInfo.PositionsRelegatedToLowerLeague)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
            }
            else if (fraction.ToLower() == "upper fraction" &&
                    leagueInfo.PositionsPromotedToChampionsLeague +
                    leagueInfo.PositionsPromotedToConferenceLeague +
                    leagueInfo.PositionsPromotedToEuropaLeague +
                    leagueInfo.PositionsPromotedToUpperLeague >
                    position)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (fraction.ToLower() == "lower fraction" &&
                     position >= teamLength - leagueInfo.PositionsRelegatedToLowerLeague)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ResetColor();
            }
        }
    }
}

