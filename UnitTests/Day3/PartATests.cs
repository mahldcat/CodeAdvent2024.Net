using FluentAssertions;

namespace UnitTests.Day3;

public class PartATests
{
    [Fact]
    public void ExampleTest()
    {
        string exampleMemory = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        int expected = 161;

        Dailies.AdventDay3.PartA.ParseMemory(exampleMemory).Should().Be(expected);
    }
}