using FluentAssertions;

namespace UnitTests.Day4;

using Dailies.AdventDay4;
using WordSearch = List<List<char>>;


public class TestDay4PartB
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
    public void TestWordSearchOnSampleData()
    {
        int expected = 9;
        PartB.Solution(rawData).Should().Be(expected);
    }
}