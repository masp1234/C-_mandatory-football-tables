

## Solution

Vi har lavet et program, der vha en "setup.csv" fil opretter ligaer ud fra hver linje i filen og med det format som angives. Derefter læser den en "teams.csv" fil, hvor teams indgår med den liga de spiller i.
Efter ligaerne med de dertilhørende teams er sat op, kører programmet igennem alle de "rounds" filer der er, udregner og opdaterer resultater for teamsene, og til sidst udskrives en sorteret pointtavle til terminalen.

## Usage

For at bruge vores program skal vi have en setup, team og en eller flere rundefiler

En setup kunne se således ud:

```
League;promote to Champions league;promote to Europe league;promote to Conference League;promote to an upper league;relegated to a lower league;
Superligaen;1;1;1;1;2;
Nordicbet;1;1;1;1;2;
```
Bruger vi ovenstående setup fil, får vi 2 ligaer med det format man har valgt(i dette tilfælde det samme)

En teams fil kunne se således ud:

```
Abbreviation;Full name;Special ranking;League;
FCF;FC Fredericia;P;Nordicbet;
FCN;FC Nordsjælland;P;Superligaen;
FCK;FC København;W;Superligaen;
```
Bruger du denne fil sammen med setup fil får du en Superliga med 2 hold og en Nordicbetliga med 1 hold

En round fil kunne se således ud:

```
league;home;away;homegoals;awaygoals;
Nordicbet;HIF;SJ;0;3;
Nordicbet;HF;NBK;0;5;
Nordicbet;NFC;HIK;6;0;
```

Runde filen bruges til at opdatere holdenes point

## Errors

```
The match in file: round-003 has invalid data on line: 2
```
Denne fejl betyder at en af målværdierne ikke er et tal

```
FCK as home team has already played against BIF as away team. The error is in round: 6
```
Vi har valgt ikke at throw en exception, da vi ikke har data der overholder ovenstående regel. Dog bliver fejlbeskeden printet til terminalen og kampen ignoreret.

```
HIF is playing against HIF. A team playing against itself is not allowed. The error is happening in file: round-001 on line: 2
```
Dette er et exempel på en exception, som der kan blive kaldt, hvis et hold spiller mod sig selv.

