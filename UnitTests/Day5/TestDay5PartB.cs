using Dailies.AdventDay5;
using FluentAssertions;

namespace UnitTests.Day5;

public class TestDay5PartB
{
    [Fact]
    public void VerifyExampleDataOnPart2()
    {
        int expectedResult = 123;
        PartB.Solution(TestParser.ExampleData).Should().Be(expectedResult);
        
        
    }
}