using FluentAssertions;

namespace UnitTests.Day3;

public class PartATests
{
    [Fact]
    public void ValidateIntParse()
    {
        string intStr = "123";
        int startIdx = 0;
        int expected = 123;
        Dailies.AdventDay3.PartA.GetInteger(intStr, ref startIdx).Should().Be(expected);

        startIdx.Should().Be(3);
    }
    
    [Fact]
    public void ValidateIntParseMidString()
    {
        string intStr = "borf123";
        int startIdx = 4;
        int expected = 123;
        Dailies.AdventDay3.PartA.GetInteger(intStr, ref startIdx).Should().Be(expected);

        startIdx.Should().Be(7);
    }
    
    [Fact]
    public void ExampleTest()
    {
        string exampleMemory = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        int expected = 161;

        Dailies.AdventDay3.PartA.ParseMemory(exampleMemory).Should().Be(expected);
    }
}