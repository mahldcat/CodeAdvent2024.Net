using Dailies.AdventDay5;
using FluentAssertions;

namespace UnitTests.Day5;

public class TestParser
{
    //this SHOULD really be in a testutils class....
    public static string ExampleData =
@"47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13

75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47";
    [Fact]
    public void VerifyParse()
    {
        Day5ParsedData pd = Utils.ParseRawData(ExampleData);

        int expectedPageOrders = 6;
        int expectedRulesCount = 6;
        int expectedRuleListCount = 4;
        
        pd.PageOrders.Count.Should().Be(expectedPageOrders);
        pd.OrderingRules.Count.Should().Be(expectedRulesCount);
        pd.OrderingRules[47].Count.Should().Be(expectedRuleListCount);

    }
}