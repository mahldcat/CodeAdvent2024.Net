// See https://aka.ms/new-console-template for more information

using Dailies;
using Dailies.AdventDay1;

using DispatchTable = System.Collections.Generic.Dictionary<int, System.Func<Dailies.InputFetch,System.Threading.Tasks.Task>>;
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


        int foundWords = Dailies.AdventDay4.PartA.Solution(wordGridRaw);
        Console.WriteLine($"Words Found (Part A): {foundWords}");

        foundWords = Dailies.AdventDay4.PartB.Solution(wordGridRaw);
        Console.WriteLine($"Words Found (Part B): {foundWords}");
    }

    public static async Task RunDay5(InputFetch fetch)
    {
        string rawData = await fetch.GetDay5Input();
    }
    public static async Task RunDay6(InputFetch fetch)
    {
        string rawData = await fetch.GetDay6Input();
    }
    public static async Task RunDay7(InputFetch fetch)
    {
        string rawData = await fetch.GetDay7Input();
    }
    public static async Task RunDay8(InputFetch fetch)
    {
        string rawData = await fetch.GetDay8Input();
    }
    public static async Task RunDay9(InputFetch fetch)
    {
        string rawData = await fetch.GetDay9Input();
    }
    public static async Task RunDay10(InputFetch fetch)
    {
        string rawData = await fetch.GetDay10Input();
    }
    public static async Task RunDay11(InputFetch fetch)
    {
        string rawData = await fetch.GetDay11Input();
    }


    private static DispatchTable SolutionDispatch = new DispatchTable
    {
        { 1, RunDay1 },
        { 2, RunDay2 },
        { 3, RunDay3 },
        { 4, RunDay4 },
        { 5, RunDay5 },
        { 6, RunDay6 },
        { 7, RunDay7 },
        { 8, RunDay8 },
        { 9, RunDay9 },
        { 10, RunDay10 },
        { 11, RunDay11 },
    };
    

    public static async Task Main(string[] args)
    {
        //TODO: Refactor all of this into host builder with Services!
        if (args.Length <2)
        {
            Console.Error.WriteLine("Must supply 'DayVal' 'sessionToken' from the advent of code");
            Environment.Exit(-1);
        }

        int id = int.Parse(args[0]);
        string sessionToken = args[1];
        
        InputFetch fetch = new InputFetch(sessionToken);

        await RunDay4(fetch);
    }    
}
