namespace Dailies.AdventDay2;

public static class PartA
{
    public static bool VerifyLevel(List<int> reportLevel)
    {
        int prevLevel = -1;//eyeball on data shows this is a good initializer
        bool? isIncreasing = null;
        
        foreach (int levelValue in reportLevel)
        {
            if (prevLevel == -1)
            {
                prevLevel = levelValue;
                continue;
            }
            
            //sort out if the entries are increasing or decreasing
            if (isIncreasing == null)
            {
                isIncreasing = levelValue > prevLevel;
            }

            //handle scenario of a "hill" or a "valley"
            if ((isIncreasing.Value && levelValue < prevLevel) ||
                (!isIncreasing.Value && levelValue > prevLevel))
            {
                return false;
                //throw new Exception("Hill or Valley");
            }

            //Any two adjacent levels differ by at least one and at most three.
            int difference = Math.Abs(levelValue - prevLevel);
            if (difference is < 1 or > 3)
            {
                return false;
                //throw new Exception($"Height value:{difference} prev:{prevLevel} current:{levelValue}");
            }

            prevLevel = levelValue;
        }

        return true;
    }
}