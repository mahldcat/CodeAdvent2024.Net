using FluentAssertions;

namespace UnitTests.Day3;
using ParseList=List<(string substring, int index)>;

public class PartBTests
{
    [Fact]
    public void VerifyExampleMemory()
    {
        string exampleMemory = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
        int expected = 48;

        Dailies.AdventDay3.PartB.ParseMemoryWithThreeTokens(exampleMemory).Should().Be(expected);

    }
    
    [Fact]
    public void VerifyParseList()
    {
        string exampleMemory = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

        ParseList parsedResult= Dailies.AdventDay3.PartB.ParseInput(exampleMemory);

        parsedResult.Count.Should().Be(7);
        int idx = 0;
        parsedResult[idx].substring.Should().Be("mul(");
        parsedResult[idx].index.Should().Be(1);

        ++idx;
        parsedResult[idx].substring.Should().Be("don't()");
        parsedResult[idx].index.Should().Be(20);

        ++idx;
        parsedResult[idx].substring.Should().Be("mul(");
        parsedResult[idx].index.Should().Be(28);
        ++idx;
        parsedResult[idx].substring.Should().Be("mul(");
        parsedResult[idx].index.Should().Be(37);
        ++idx;
        parsedResult[idx].substring.Should().Be("mul(");
        parsedResult[idx].index.Should().Be(48);

        ++idx;
        parsedResult[idx].substring.Should().Be("do()");
        parsedResult[idx].index.Should().Be(59);

        ++idx;
        parsedResult[idx].substring.Should().Be("mul(");
        parsedResult[idx].index.Should().Be(64);


    }
}