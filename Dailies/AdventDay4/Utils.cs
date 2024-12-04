namespace Dailies.AdventDay4;

public static class Utils
{

    public static List<List<char>> ParseRawData(string rawData)
    {
        List<List<char>> parsedSearch = new List<List<char>>();

        using (StringReader reader = new StringReader(rawData))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                parsedSearch.Add(new List<char>(line.ToCharArray()));
            }
        }        

        return parsedSearch;
    }
    
}