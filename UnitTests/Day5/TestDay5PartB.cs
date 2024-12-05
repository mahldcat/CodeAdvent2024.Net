using Dailies.AdventDay5;
using FluentAssertions;

namespace UnitTests.Day5;

public class TestDay5PartB
{
    [Fact]
    public void VerifyFixedOrdering()
    {
        Day5ParsedData pd = Utils.ParseRawData(TestParser.ExampleData);
        List<int> testSet = pd.PageOrders[3];
        //75,97,47,61,53 becomes 
        
        List<int> expected = new List<int>{97,75,47,61,53};
        
        PartB.FixOrdering(pd.OrderingRules,testSet);

        for (int i = 0; i < expected.Count; ++i)
        {
            testSet[i].Should().Be(expected[i]);
        }
    }

    [Fact]
    public void VerifyExampleDataOnPart2()
    {
        int expectedResult = 123;
        PartB.Solution(TestParser.ExampleData).Should().Be(expectedResult);
    }
}