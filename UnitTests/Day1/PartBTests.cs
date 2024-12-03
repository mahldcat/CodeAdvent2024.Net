using Dailies.AdventDay1;
using FluentAssertions;

namespace UnitTests.Day1;

public class PartBTests
{
    [Fact]
    public void SimilarityWithSampleData()
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

        int expectedSimilarity = 31;
        List<string> rawReport = new List<string>(sampleData);
        InputParser.ParseInput(rawReport, out var left, out var right);

        PartB.Similarity(left, right).Should().Be(expectedSimilarity);
    }
}