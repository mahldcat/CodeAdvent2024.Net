namespace Dailies.AdventDay5;

using OrderRules = IDictionary<int,IList<int>>;

public class PartB
{
    public static void FixOrdering(OrderRules rules, List<int> pages)
    {
        //75,97,47,61,53,13,29 becomes 97,75,47,61,53,29,13
        int[] fixedPages = new int[pages.Count];
        int idx = 0;

        while (idx < pages.Count)
        {
            int toAdjust = pages[idx];
            int slotCt = 0;
            foreach (int entry in pages)
            {
                if (entry == toAdjust)
                {
                    continue;//this is the value
                }
                if (!rules.ContainsKey(entry))
                {
                    continue; //nothing on the entry we are checking
                }

                if (rules[entry].Contains(toAdjust))
                {
                    ++slotCt;
                }
            }

            fixedPages[slotCt] = toAdjust;
            ++idx;
        }
        //we now have fixedPages that should have all the values in it
        
        pages.Clear();
        pages.AddRange(fixedPages);
    }
    public static int Solution(string rawInput)
    {

        Day5ParsedData pd = Utils.ParseRawData(rawInput);

        int midPointSum = 0;
        
        foreach(List<int> pageOrderList in pd.PageOrders)
        {
            if (!Utils.VerifyList(pd.OrderingRules, pageOrderList))//bad list
            {
                FixOrdering(pd.OrderingRules,pageOrderList);
                midPointSum += Utils.GetMiddle(pageOrderList);
            }
        }

        return midPointSum;
        
    }
}