using Dailies.AdventDay5;
using FluentAssertions;

namespace UnitTests.Day5;

public class TestDay5PartA
{
    [Fact]
    public void VerifyExampleDataOnPart1()
    {
        int expectedResult = 143;
        PartA.Solution(TestParser.ExampleData).Should().Be(expectedResult);
    }
}