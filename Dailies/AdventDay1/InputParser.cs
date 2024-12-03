namespace Dailies.AdventDay1;

public static class InputParser
{
    public static void ParseInput(IList<string> locations, out List<int> listLeft, out List<int> listRight)
    {
        listLeft = new List<int>();
        listRight = new List<int>();
        
        foreach (string location in locations)
        {
            string[] rawSplit = location.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            listLeft.Add(int.Parse(rawSplit[0]));
            listRight.Add(int.Parse(rawSplit[1]));
        }
    }
}