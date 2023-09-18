using System;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;


public static class DataHandler
{
    public static League? currentLeague;
    public static int round = 1;
    public static void LeagueStart(string leagueName)
    {

        currentLeague = CsvReader.LoadLeagueFromCSV(leagueName);

        currentLeague.Teams = CsvReader.LoadTeamsFromCSV();

        HandleScores(currentLeague.Teams);

        // handlescores top rounds
        // handlescores bottom rounds
        // new method to handle lists seperatly?

    }

    public static void HandleScores(List<Team> teams)
    {

        for (int i = 1; i < 33; i++)
        {
            List<Result> results = CsvReader.LoadRoundFromCSV("round" + i.ToString() + ".csv");



            for (int j = 0; j < results.Count; j++)
            {
                int indexHome = currentLeague.Teams.FindIndex(team => team.AbbreviatedName == results[j].HomeTeam);
                int indexAway = currentLeague.Teams.FindIndex(team => team.AbbreviatedName == results[j].AwayTeam);

                // Compares goals and sets wins, loss and draw for specific team. Also sets score
                if (results[j].HomeScore > results[j].AwayScore)
                {
                    currentLeague.Teams[indexHome].Wins++;
                    currentLeague.Teams[indexAway].Losses++;

                    currentLeague.Teams[indexHome].Points += 3;

                }
                else if (results[j].HomeScore < results[j].AwayScore)
                {
                    currentLeague.Teams[indexAway].Wins++;
                    currentLeague.Teams[indexHome].Losses++;

                    currentLeague.Teams[indexAway].Points += 3;

                }
                else
                {
                    currentLeague.Teams[indexAway].Draws++;
                    currentLeague.Teams[indexHome].Draws++;

                    currentLeague.Teams[indexHome].Points += 1;
                    currentLeague.Teams[indexAway].Points += 1;

                }
                // sets games played
                currentLeague.Teams[indexAway].GamesPlayed++;
                currentLeague.Teams[indexHome].GamesPlayed++;

                // sets goals for
                currentLeague.Teams[indexHome].GoalsFor += results[j].HomeScore;
                currentLeague.Teams[indexAway].GoalsFor += results[j].AwayScore;

                //set goals against
                currentLeague.Teams[indexHome].GoalsAgainst += results[j].AwayScore;
                currentLeague.Teams[indexAway].GoalsAgainst += results[j].HomeScore;

                // sets goaldifference
                currentLeague.Teams[indexHome].GoalDifference = currentLeague.Teams[indexHome].GoalsFor - currentLeague.Teams[indexHome].GoalsAgainst;
                currentLeague.Teams[indexAway].GoalDifference = currentLeague.Teams[indexAway].GoalsFor - currentLeague.Teams[indexAway].GoalsAgainst;

                }

            TeamsToPrint();
            round++;

        }
        //return teams;
    }

    public static void TeamsToPrint()
    {
       
        List<Team> topTeams = new List<Team>();
        List<Team> bottomTeams = new List<Team>();


        // handle above round 22
        if (round > 22)
        {

            topTeams = currentLeague.Teams.Where(team => team.Top6).ToList();
            bottomTeams = currentLeague.Teams.Where(team => !team.Top6).ToList();

            ResultWriter.PrintRoundTable(topTeams, currentLeague.LeagueName, round, true, true);
            ResultWriter.PrintRoundTable(bottomTeams, currentLeague.LeagueName, round, true, false);
        }
        else // handle round 22 and below
        {
            List<Team> sortedTeams = currentLeague.Teams.OrderByDescending(team => team.Points).ToList();

            if(round == 22) { 
            for (int i = 0; i < 6; i++)
            {
                
                currentLeague.Teams[i].Top6 = true;
            }
            }
            ResultWriter.PrintRoundTable(currentLeague.Teams, currentLeague.LeagueName, round, false, false);
        }
    }
}
