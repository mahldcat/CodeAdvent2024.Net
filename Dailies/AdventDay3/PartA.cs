using System.Text;

namespace Dailies.AdventDay3;

public static class PartA
{

    public static int ParseMemory(string memoryString)
    {
        int toReturn = 0;
        int startIdx = 0;

        while ((startIdx = memoryString.IndexOf(Utils.MUL_START, startIdx)) != -1)
        {
            int? leftVal = null;
            int? rightVal = null;

            //we now have an entry point (startIdx) for the idx of "mul("...advance our idx to the next char
            // after the '('  [by 4]
            startIdx += Utils.MUL_START_LEN;
            // so now we have "2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"

            leftVal = Utils.GetInteger(memoryString, ref startIdx);
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
            rightVal = Utils.GetInteger(memoryString, ref startIdx);//now get the right value
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