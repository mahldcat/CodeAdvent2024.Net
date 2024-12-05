namespace Dailies.AdventDay5;

using OrderRules = IDictionary<int,IList<int>>;

public class PartA
{


    public static int Solution(string rawInput)
    {
        Day5ParsedData pd = Utils.ParseRawData(rawInput);

        int midPointSum = 0;
        
        foreach(List<int> pageOrderList in pd.PageOrders)
        {
            if (Utils.VerifyList(pd.OrderingRules, pageOrderList))
            {
                midPointSum += Utils.GetMiddle(pageOrderList);
            }
        }

        return midPointSum;
    }
}