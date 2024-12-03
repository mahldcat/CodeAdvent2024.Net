using System.Text;

namespace Dailies.AdventDay3;

public static class PartA
{
    private const string MUL_START = "mul(";

    private const int MUL_START_LEN = 4;
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
        int curLen = 0;
        bool digitFound = false;

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
    public static int ParseMemory(string memoryString)
    {
        int toReturn = 0;
        int startIdx = 0;

        while ((startIdx = memoryString.IndexOf(MUL_START, startIdx)) != -1)
        {
            int? leftVal = null;
            int? rightVal = null;

            //we now have an entry point (startIdx) for the idx of "mul("...advance our idx to the next char
            // after the '('  [by 4]
            startIdx += MUL_START_LEN;
            // so now we have "2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"

            leftVal = GetInteger(memoryString, ref startIdx);
            if (leftVal == null)// we were not able to get an integer--e.g. "mul(borf", so advance to the next entry
            {
                continue;
            }
            //first example we should now be looking at ",4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"
            if (startIdx>memoryString.Length || memoryString[startIdx++] != ',')
            {
                continue;
            }
            //first example is now "4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"
            rightVal = GetInteger(memoryString, ref startIdx);//now get the right value
            if (rightVal == null)// we were not able to get an integer--so advance to the next entry
            {
                continue;
            }

            if (startIdx>memoryString.Length || memoryString[startIdx++] != ')')
            {
                continue;
            }

            //we have a legit command--go ahead and append it to the return value
            toReturn += (leftVal.Value * rightVal.Value);
            
        }

        return toReturn;
    }
}