namespace Dailies.AdventDay1;

public class PartA
{
    public static int DistanceCalc(List<int> left, List<int> right)
    {
        left.Sort();
        right.Sort();

        int totalDistance = 0;

        for (int i = 0; i < left.Count; ++i)
        {
            totalDistance += Math.Abs(left[i] - right[i]);
        }

        return totalDistance;
    }
}