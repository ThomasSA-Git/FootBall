using System;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;


public static class DataHandler
{

    public static void LeagueStart(string leagueName)
    {

        League currentLeague = CsvReader.LoadLeagueFromCSV(leagueName);

        currentLeague.Teams = CsvReader.LoadTeamsFromCSV();

        for (int i = 1; i < 23; i++)
        {
            List<Result> results = CsvReader.LoadRoundFromCSV("round" + i.ToString() + ".csv");

            for (int j = 0; j < results.Count; j++)
            {
                int indexHome = currentLeague.Teams.FindIndex(team => team.AbbreviatedName == results[j].HomeTeam);
                int indexAway = currentLeague.Teams.FindIndex(team => team.AbbreviatedName == results[j].AwayTeam);

                // Compares scores and sets wins, loss and draw for specific team. Also sets score
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

                ResultWriter.PrintRoundTable(currentLeague.Teams, currentLeague.LeagueName);
                Console.WriteLine(currentLeague.Teams[0].AbbreviatedName + " " + currentLeague.Teams[0].Wins + " " + currentLeague.Teams[0].GoalsAgainst);
            }
        }
    }
}


