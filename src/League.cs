using System;
public class League
{
    public string LeagueName { get; set; }
    public int PromoteToChampionsLeague { get; set; }
    public int PromoteToEuropaLeague { get; set; }
    public int PromoteToConferenceLeague { get; set; }
    public int PromoteToUpperLeague { get; set; }
    public int RelegateToLowerLeague { get; set; }
    public int Rounds { get; set; }

    public List<Team> Teams { get; set; } = new List<Team>();

    public League(
        string leagueName,
        int promoteToChampionsLeague,
        int promoteToEuropaLeague,
        int promoteToConferenceLeague,
        int promoteToUpperLeague,
        int relegateToLowerLeague,
        int rounds)
    {
        LeagueName = leagueName;
        PromoteToChampionsLeague = promoteToChampionsLeague;
        PromoteToEuropaLeague = promoteToEuropaLeague;
        PromoteToConferenceLeague = promoteToConferenceLeague;
        PromoteToUpperLeague = promoteToUpperLeague;
        RelegateToLowerLeague = relegateToLowerLeague;
        Rounds = rounds;
    }
}