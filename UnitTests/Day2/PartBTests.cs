using Dailies.AdventDay2;
using FluentAssertions;

namespace UnitTests.Day2;

public class PartBTests
{
    private void VerifyReportDampen(string report, bool expected)
    {
        PartB.VerifyLevelWithDampen(ParseReport.ReportToLevelList(report)).Should().Be(expected, report);
    }
    
    [Fact]
    public void Test1Dampen()
    {
        VerifyReportDampen("7 6 4 2 1",true);
    }
    
    [Fact]
    public void Test2Dampen()
    {
        VerifyReportDampen("1 2 7 8 9",false);
    }
    [Fact]
    public void Test3Dampen()
    {
        VerifyReportDampen("9 7 6 2 1",false);
    }
    [Fact]
    public void Test4Dampen()
    {
        VerifyReportDampen("1 3 2 4 5",true);
    }
    [Fact]
    public void Test5Dampen()
    {
        VerifyReportDampen("8 6 4 4 1",true);
    }
    [Fact]
    public void Test6Dampen()
    {
        VerifyReportDampen("1 3 6 7 9",true);
    }

    [Fact]
    public void Test7Dampen()
    { 
        var output = new StringWriter();
        Console.SetOut(output);

        VerifyReportDampen("1 1 2 3 4 5",true);
    }
    
    [Fact]
    public void Test8Dampen()
    {
        VerifyReportDampen("1 1 8 3 4 5",false);
    }

    [Fact]
    public void Test9AdditionalEdgeCases()
    {
        string[] validScenarios = new string[]
        {
            "48 46 47 49 51 54 56", // throw out the first element
            "1 1 2 3 4 5",
            "1 2 3 4 5 5",
            "5 1 2 3 4 5", //another one to throw out on first element
            "1 4 3 2 1", //first element madness
            "1 6 7 8 9", //first element 
            "1 2 3 4 3", //last element?
            "9 8 7 6 7",
            "7 10 8 10 11",
            "29 28 27 25 26 25 22 20"
        };

        foreach (string rep in validScenarios)
        {
            VerifyReportDampen(rep, true);
        }
    }
}