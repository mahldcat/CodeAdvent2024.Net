using Dailies.AdventDay2;
using FluentAssertions;
using Xunit.Abstractions;

namespace UnitTests.Day2;

public class PartATests
{
    private readonly ITestOutputHelper _output;

    public PartATests(ITestOutputHelper output)
    {
        _output = output;
    }
    /*
7 6 4 2 1  safe
1 2 7 8 9  unsafe
9 7 6 2 1  unsafe
1 3 2 4 5  unsafe
8 6 4 4 1  unsafe
1 3 6 7 9  safe
     */
    private void VerifyReport(string report, bool expected)
    {
        PartA.VerifyLevel(ParseReport.ReportToLevelList(report)).Should().Be(expected);    
    }

    [Fact]
    public void Test1Base()
    {
        VerifyReport("7 6 4 2 1",true);
    }
    
    [Fact]
    public void Test2Base()
    {
        VerifyReport("1 2 7 8 9",false);
    }
    [Fact]
    public void Test3Base()
    {
        VerifyReport("9 7 6 2 1",false);
    }
    [Fact]
    public void Test4Base()
    {
        VerifyReport("1 3 2 4 5",false);
    }
    [Fact]
    public void Test5Base()
    {
        VerifyReport("8 6 4 4 1",false);
    }
    [Fact]
    public void Test6Base()
    {
        VerifyReport("1 3 6 7 9",true);
    }
}
