using System;

public class Result
{
	public string HomeTeam { get; set; }
	public string AwayTeam { get; set; }
	public int HomeScore { get; set; }
	public int AwayScore { get; set; }

    public Result(string homeTeam, string awayTeam, int homeScore, int awayScore)
    {
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        HomeScore = homeScore;
        AwayScore = awayScore;
    }
}

