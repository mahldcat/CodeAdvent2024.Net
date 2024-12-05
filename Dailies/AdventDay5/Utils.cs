using System.Collections;
using System.Globalization;

namespace Dailies.AdventDay5;

using OrderRules = IDictionary<int,IList<int>>;

public struct Day5ParsedData
{
    public OrderRules OrderingRules { get; set; }
    public IList<List<int>> PageOrders { get; set; }
}
public static class Utils
{
    public static int GetMiddle(List<int> orderList)
    {
        return orderList[orderList.Count / 2];
    }
    public static bool VerifyList(OrderRules rules,List<int> orderList)
    {

        for (int i = 0; i < orderList.Count; ++i)
        {
            //we don't care about the final value in the list
            //...we know the other pages are to be printed before it
            int pageToCheck = orderList[i];
            if (!rules.ContainsKey(pageToCheck))
            {
                //no rule found for the page, according to the rules
                //this is a "freebie"
                continue;
            }

            //pageToCheck must come before the rest of these pages
            IList<int> pageRules = rules[pageToCheck];

            //forward scan the digits
            for (int j = i + 1; j < orderList.Count; ++j)
            {
                int againstPage = orderList[j];
                if (!pageRules.Contains(againstPage))
                {
                    return false;
                }
            }

            //scan back in the list 
            //if one of these pages shows up in the rules
            // it was printed BEFORE the page in question...a violation!
            //
            //61,13,29
            //
            // 29-before->{13} 
            for (int j = i - 1; j >= 0; --j)
            {
                int againstPage = orderList[j];
                if (pageRules.Contains(againstPage))
                {
                    return false;
                }
            }
            //all of the pages in the list after the i'th element are to be printed AFTER...we are good
        }
        
        return true;
    }

    public static Day5ParsedData ParseRawData(string rawData)
    {
        Day5ParsedData pd = new Day5ParsedData
        {
            OrderingRules = new Dictionary<int, IList<int>>(),
            PageOrders = new List<List<int>>()
        };

        bool buildPageOrders = false;
        using (StringReader reader = new StringReader(rawData))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    buildPageOrders = true;//advance to the next section
                    continue;
                }

                if (buildPageOrders)
                {

                    List<int> pageOrder = new List<int>();
                    foreach (string entry in line.Split(",", StringSplitOptions.RemoveEmptyEntries))
                    {
                        pageOrder.Add(int.Parse(entry));
                    }
                    
                    if(pageOrder.Count%2==0)
                    {
                        throw new InvalidDataException($"Page list had {pageOrder.Count} elements in it (even number)");
                    }
                    pd.PageOrders.Add(pageOrder);
                }
                else
                {
                    string[] orderRule = line.Split("|", StringSplitOptions.RemoveEmptyEntries);
                    int before = int.Parse(orderRule[0]);
                    int after = int.Parse(orderRule[1]);

                    if (pd.OrderingRules.ContainsKey(before))
                    {
                        pd.OrderingRules[before].Add(after);
                    }
                    else
                    {
                        pd.OrderingRules.Add(before, new List<int>{ after});
                    }
                }
            }
        }       

        return pd;
    }
}