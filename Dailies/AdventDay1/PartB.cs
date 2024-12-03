namespace Dailies.AdventDay1;
using IFrequency= IDictionary<int,int>;
using Frequency = Dictionary<int,int>;

public static class PartB
{
    private static IFrequency ToFrequencyLookup(List<int> locations)
    {
        IFrequency frequency = new Frequency();
        foreach (int l in locations)
        {
            if (frequency.ContainsKey(l))
            {
                frequency[l] += 1;
            }
            else
            {
                frequency[l] = 1;
            }
        }
        return frequency;
    }

    
    private static int GetFrequencyVal(this IFrequency haystack, int needle)
    {
        if (haystack.TryGetValue(needle, out var val))
        {
            return val;
        }
        return 0;
    }
    public static int Similarity(List<int> left, List<int> right)
    {
        IFrequency frequency = ToFrequencyLookup(right);

        int similarySum = 0;

        foreach (int l in left)
        {
            similarySum += (l * frequency.GetFrequencyVal(l));
        }

        return similarySum;
    }   
}