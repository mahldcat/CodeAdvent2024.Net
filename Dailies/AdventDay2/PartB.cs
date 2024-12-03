namespace Dailies.AdventDay2;

public static class PartB
{

    public static bool VerifyLevelWithDampen(List<int> report)
    {
        //friend of mine gave me this solution--it's absolutely NOT optimized
        //verify the report first with no changes
        // after that create a replica of the report list, remove the nth element from it and recheck
        //
        if (PartA.VerifyLevel(report))
        {
            return true;
        }
        
        for (int i = 0; i < report.Count; ++i)
        {
            //if I were to alter the VerifyLevel function to have it skip the element at location n
            //then I could do away with this step:
            List<int> clonedReport = new List<int>(report);
            clonedReport.RemoveAt(i);
            if (PartA.VerifyLevel(clonedReport))
            {
                return true;
            }
        }
        return false;
    }
    
    
}