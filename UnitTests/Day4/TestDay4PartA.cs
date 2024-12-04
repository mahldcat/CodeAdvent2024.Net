using FluentAssertions;

namespace UnitTests.Day4;

using Dailies.AdventDay4;
using WordSearch = List<List<char>>;

public class TestDay4PartA
{
    private string rawData= 
@"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX";

    [Fact]
    public void TestStringToWordSearchLists()
    {
        WordSearch ws = Utils.ParseRawData(rawData);
        int expectedRowCt = 10;
        int expectedColCt = 10;

        ws.Count.Should().Be(expectedRowCt, $"{expectedRowCt} lines in the rawData");

        foreach (List<char> row in ws)
        {
            row.Count.Should().Be(expectedColCt, $"{expectedColCt} chars in the row");
            
        }
    }

    [Fact]
    public void TestWordSearchOnSampleData()
    {
        int expected = 18;
        PartA.Solution(rawData).Should().Be(expected);
    }
}