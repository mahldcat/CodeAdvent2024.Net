﻿// See https://aka.ms/new-console-template for more information

using Dailies;
using Dailies.AdventDay1;

public class Driver
{
    public static async Task RunDay1(InputFetch fetch)
    {
        IList<string> input = await fetch.GetDay1Input();
        Console.WriteLine($"Input is {input.Count} elements");

        Dailies.AdventDay1.InputParser.ParseInput(input, out var left, out var right);

        int distance= Dailies.AdventDay1.PartA.DistanceCalc(left, right);
        Console.WriteLine($"Distance:{distance}");

        int similarity = Dailies.AdventDay1.PartB.Similarity(left, right);
        Console.WriteLine($"Similarity:{similarity}");
        

    }

    public static async Task RunDay2(InputFetch fetch)
    {
        IList<string> input = await fetch.GetDay2Input();
        Console.WriteLine($"Input is {input.Count} elements");

        int reportSummary = Dailies.AdventDay2.Report.GetLevelSummary(input, Dailies.AdventDay2.PartA.VerifyLevel);
        Console.WriteLine($"Report Summary, no Dampen:{reportSummary}");

        reportSummary= Dailies.AdventDay2.Report.GetLevelSummary(input,Dailies.AdventDay2.PartB.VerifyLevelWithDampen);
        Console.WriteLine($"Report Summary, with dampening:{reportSummary}");
    }

    public static async Task RunDay3(InputFetch fetch)
    {
        string memoryBuffer = await fetch.GetDay3Input();

        int combinedValues= Dailies.AdventDay3.PartA.ParseMemory(memoryBuffer);
        Console.WriteLine($"Result of Multipliers: {combinedValues}");

        combinedValues = Dailies.AdventDay3.PartB.ParseMemoryWithThreeTokens(memoryBuffer);
        Console.WriteLine($"Result of Multipliers with do/don't: {combinedValues}");
    }
    public static async Task RunDay4(InputFetch fetch)
    {
        string wordGridRaw = await fetch.GetDay4Input();
        
        //Console.WriteLine(wordGridRaw);

        int foundWords = Dailies.AdventDay4.PartA.Solution(wordGridRaw);
        Console.WriteLine($"Words Found (Part A): {foundWords}");

        foundWords = Dailies.AdventDay4.PartB.Solution(wordGridRaw);
        Console.WriteLine($"Words Found (Part B): {foundWords}");

    }

  public static async Task Main(string[] args)
    {
        //TODO: Refactor all of this into host builder with Services!
        if (args.Length == 0)
        {
            Console.Error.WriteLine("Must supply the sessionToken from the advent of code");
            Environment.Exit(-1);
        }
        string sessionToken = args[0];
        InputFetch fetch = new InputFetch(sessionToken);

        await RunDay4(fetch);
    }    
}
