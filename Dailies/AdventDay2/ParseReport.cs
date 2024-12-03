using System.Globalization;

namespace Dailies.AdventDay2;

public static class ParseReport
{
    public static List<int> ReportToLevelList(string report)
    {
        List<int> reportList = new List<int>();

        //we should never get this, but figure to play the safety
        if (string.IsNullOrWhiteSpace(report))
        {
            return reportList;
        }

        foreach (string num in report.Split(' '))
        {
            reportList.Add(int.Parse(num));
        }
        
        return reportList;
    }
}