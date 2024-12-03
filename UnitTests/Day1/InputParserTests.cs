using Dailies.AdventDay1;
using FluentAssertions;

namespace UnitTests.Day1;

public class InputParserTests{

    [Fact]
    public void VerifyParser()
    {
        string[] rawInput = new string[]
        {
            "11111   22222",
            "33333   44444"
        };

        List<string> reportData = new List<string>(rawInput);
        
        InputParser.ParseInput(reportData, out var leftList, out var rightList);

        leftList[0].Should().Be(11111);
        rightList[0].Should().Be(22222);
        leftList[1].Should().Be(33333);
        rightList[1].Should().Be(44444);
        
    }
}