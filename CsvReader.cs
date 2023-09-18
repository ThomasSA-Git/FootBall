using System;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;

public static class CsvReader
{
    public static League LoadLeagueFromCSV(string fileName)
    {

        string workingDirectory = Environment.CurrentDirectory;
        string currentDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;
        string csv = Path.Combine(currentDirectory, "csv-files", fileName);

        try
        {

            if (!File.Exists(csv))
            {
                throw new FileNotFoundException("No CSV file found");
            }

            using (var reader = new StreamReader(csv))
            {
                reader.ReadLine();

                string dataLine = reader.ReadLine()!;


                string[] data = dataLine.Split(',');

                if (data.Length == 7)
                {
                    string leagueName = data[0].Trim();
                    int positionsToChampionsLeague = int.Parse(data[1].Trim());
                    int positionsToEuropeLeague = int.Parse(data[2].Trim());
                    int positionsToConferenceLeague = int.Parse(data[3].Trim());
                    int positionsToUpperLeague = int.Parse(data[4].Trim());
                    int positionsToLowerLeague = int.Parse(data[5].Trim());
                    int rounds = int.Parse(data[6].Trim());

                    League league = new League(
                        leagueName, positionsToChampionsLeague, positionsToEuropeLeague, positionsToConferenceLeague, positionsToUpperLeague, positionsToLowerLeague, rounds
                    );

                    return league;
                }
                else
                {
                    throw new FormatException("Data doesn't work");
                }

            }
        }
        catch (Exception e)
        {
            Console.WriteLine("File does not exist. Error: " + e);
            return null;
        }
    }


    public static List<Team> LoadTeamsFromCSV()
    {

        // Construct the full path to the CSV file
        string workingDirectory = Environment.CurrentDirectory;
        string currentDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;
        string csv = Path.Combine(currentDirectory, "csv-files", "Teams.csv");

        // Initialize the list to store teams
        List<Team> teams = new List<Team>();

        try
        {
            if (!File.Exists(csv))
            {
                throw new FileNotFoundException("No CSV file found");
            }

            using (var reader = new StreamReader(csv))
            {
                reader.ReadLine();

                // Read data lines and make the list of teams
                while (!reader.EndOfStream)
                {
                    string dataLine = reader.ReadLine()!.Trim();
                    string[] data = dataLine.Split(',');

                    if (data.Length >= 2) // Check for at least 2 columns
                    {
                        string abbreviation = data[0].Trim();
                        string teamName = data[1].Trim();
                        string specialRanking = data.Length > 2 ? data[2].Trim() : "";

                        // Create a Team object and add it to the list
                        Team team = new Team(abbreviation, teamName, specialRanking);
                        teams.Add(team);
                    }
                    else
                    {
                        throw new FormatException("Invalid data format in CSV");
                    }
                }
            }

            return teams;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            return null;
        }
    }

    public static List<Result> LoadRoundFromCSV(string fileName)
    {
   
        // Construct the full path to the CSV file
        string workingDirectory = Environment.CurrentDirectory;
        string currentDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;
        string csv = Path.Combine(currentDirectory, "csv-files", fileName);

        // Initialize the list to store scores
        List<Result> score = new List<Result>();

        try
        {
            if (!File.Exists(csv))
            {
                throw new FileNotFoundException("No CSV file found");
            }
           
            using (var reader = new StreamReader(csv))
            {
                // Read and discard the header line
                reader.ReadLine();


                // Read data lines and populate the list of teams
                while (!reader.EndOfStream)
                {
                    string dataLine = reader.ReadLine()!.Trim();
                    string[] data = dataLine.Split(',');

                    if (data.Length == 5) // Check for at least 5 columns
                    {
                        string homeTeamAbb = data[1].Trim();
                        string awayTeamAbb = data[2].Trim();
                        int homeTeamScore = int.Parse(data[3].Trim());
                        int awayTeamScore = int.Parse(data[4].Trim());

                        Result matchScore = new Result(homeTeamAbb, awayTeamAbb, homeTeamScore, awayTeamScore);

                        score.Add(matchScore);
                    }
                    else
                    {
                        throw new FormatException("Invalid data format in CSV");
                    }
                }
            }
            
            return score; // Return the list of scores
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            return null;
        }
    }
}