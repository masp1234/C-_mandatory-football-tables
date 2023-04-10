## Type system

```
private void SetTeams(List<Team> teams, GameMatch match, ref Team homeTeam, ref Team awayTeam)
```
Service class, line: 156

## Null handling

```
fraction ?? ""
```
View class, line: 12
## String interpolation

```
Console.WriteLine($"{leagueInfo.Name.ToUpper()} {(fraction ?? "")}");
```
View class, line: 12

## Pattern Matching

```
if (homeTeam is not null && awayTeam is not null)
```
Service class, line: 161
## Classes, structs and enums

```
internal enum MatchResult
    {
        W, L, D

    }
```

## Properties

```
public int Points { get => ((GamesDrawn * 1) + (GamesWon * 3)); }
```
Result class, line 14

## Named & optional parameters

```
public static void PrintCurrentStanding(List<Team> teams, LeagueInfo leagueInfo, string? fraction = null)
```
View class, line: 7

## Tupples, deconstruction

```
 return (homeTeam, awayTeam);
```
Service class, line: 154

```
(Team? homeTeam, Team? awayTeam) = FindTeams(match, league.UpperFraction.ToList(), league.LowerFraction.ToList());
```
Service class, line: 46

## Exception

```
throw new InvalidDataException($"The match in file: {fileName} has invalid data on line: {lineNumber}");
```
Filehandler class, line: 119

## Out

```
bool homeGoalsIsValid = int.TryParse(values[3], out int homeGoals);
```
Filehandler class, line: 141

## Arrays / Collections

```
Dictionary<string, League> leagueDictionary = new();
```
Service class, line: 187

## Ranges

```
string filePath = basePath[..^17] + path;
```
Filehandler class, line: 26



