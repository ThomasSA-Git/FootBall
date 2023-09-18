using System;

public static class ResultWriter
{
    public static string topString = "\u001b[34mTOP 6\u001b[0m";
    public static string bottomString = "\u001b[34mBOTTOM 6\u001b[0m";

    public static void PrintRoundTable(List<Team> teams, string leagueName, int round, bool finalRounds, bool top6)
    {
       

        Console.WriteLine($"\nLeague Name: \u001b[32m{leagueName}\u001b[0m\n"); // Green color for leagueName
        Console.WriteLine("ROUND: " + round);

        if (finalRounds)
        {   
            if (top6) { 
            Console.WriteLine(topString);
            }
            else { 
            Console.WriteLine(bottomString);
            }
        }

        int teamNameWidth = 10;
        string teamNameHeader = "Team".PadRight(teamNameWidth);

        Console.WriteLine($"Pos\tSM\t{teamNameHeader}\tM\tW\tD\tL\tGF\tGA\tGD\tPoints\tStreak");

        int previousPosition = -1;
        for (int i = 0; i < teams.Count; i++)
        {
            Team team = teams[i];
            string position = (i == 0 || team.Points != teams[i - 1].Points) ? (i + 1).ToString() : "-"; // Check if it's the first or has different points

            string specialMarking = team.SpecialRanking;
            string teamName = team.FullName;
            string gamesPlayed = team.GamesPlayed.ToString();
            string wins = team.Wins.ToString();
            string draws = team.Draws.ToString();
            string losses = team.Losses.ToString();
            string goalsFor = team.GoalsFor.ToString();
            string goalsAgainst = team.GoalsAgainst.ToString();
            string goalDifference = team.GoalDifference.ToString();
            string points = team.Points.ToString();
            string winningStreak = "W|D|L"; // Replace with actual streak logic

            string positionColor = i < 2 ? "\u001b[32m" : (i >= teams.Count - 2 ? "\u001b[31m" : "\u001b[0m");

            Console.WriteLine($"{positionColor}{position.PadLeft(3)}\t{specialMarking.PadRight(2)}\t{teamName.PadRight(10)}\t{gamesPlayed}\t{wins}\t{draws}\t{losses}\t{goalsFor}\t{goalsAgainst}\t{goalDifference}\t{points}\t{winningStreak}\u001b[0m");
        }

        Console.WriteLine("Do you wish to continue? Press enter to continue, or type 'exit' to quit.");

        string userInput = Console.ReadLine();

        if (userInput.ToLower() == "exit")
        {
            // Exit app or do something else, don't know yet
        }
    }
}