using System;

public class Team
{
    public string AbbreviatedName { get; set; }
    public string FullName { get; set; }
    public string SpecialRanking { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public int Draws { get; set; }
    public int GamesPlayed { get; set; }
    public int GoalsFor { get; set; }
    public int GoalsAgainst { get; set; }
    public int GoalDifference { get; set; }
    public int Points { get; set; }

    public Team(string abbreviatedName, string fullName, string specialRanking)
    {
        AbbreviatedName = abbreviatedName;
        FullName = fullName;
        SpecialRanking = specialRanking;
    
    }
}