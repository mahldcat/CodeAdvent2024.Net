using Dailies.AdventDay1;
using FluentAssertions;

namespace UnitTests.Day1;

public class PartATests
{
    [Fact]
    public void VerifyExample()
    {
        string[] sampleData = new string[]
        {
            "3   4",
            "4   3",
            "2   5",
            "1   3",
            "3   9",
            "3   3",
        };

        int expectedDistance = 11;
        List<string> rawReport = new List<string>(sampleData);
        InputParser.ParseInput(rawReport, out var left, out var right);

        PartA.DistanceCalc(left, right).Should().Be(11);
    }
}