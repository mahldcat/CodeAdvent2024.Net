namespace Dailies.AdventDay2;

public static class Report
{
    public static int GetLevelSummary(IList<string> report, Func<List<int>,bool> verifyAction)
    {
        int levelSummary = 0;
        foreach (string reportLevel in report)
        {
            if (string.IsNullOrWhiteSpace(reportLevel))
            {
                continue;
            }
            if (verifyAction(ParseReport.ReportToLevelList(reportLevel)))
            {
                ++levelSummary;
            }
        }
        return levelSummary;
    }
}