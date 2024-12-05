using System.Text;

namespace Dailies.AdventDay3;

public static class Utils
{
    public const string MUL_TOKEN = "mul(";
    public const string DONT_TOKEN = "don't()";
    public const string DO_TOKEN = "do()";

    public const int MUL_TOKEN_LEN = 4;
    public const int DONT_TOKEN_LEN = 7;
    public const int DO_TOKEN_LEN = 4;
    //mul(xxx,yyy)


    
    /// <summary>
    /// Attempts to get (and parse) the integer value from the memoryString starting at idx
    /// </summary>
    /// <param name="memoryString">the string to look at</param>
    /// <param name="startIdx">where to look</param>
    /// <returns>the parsed integer</returns>
    /// <remarks>idx should advance to the next token</remarks>
    public static int? GetInteger(string memoryString, ref int idx, int maxIntLength=3)
    {
        StringBuilder sb = new StringBuilder();
        //make sure we don't advance past the length of the string
        while(idx<memoryString.Length && char.IsDigit(memoryString[idx]))
        {
            sb.Append(memoryString[idx++]);
        }

        string rawResult = sb.ToString();
        if (rawResult.Length is >= 1 and <= 3)
        {
            return int.Parse(rawResult);
        }
        
        return null;
    }
}