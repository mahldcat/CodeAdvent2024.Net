using Dailies.AdventDay1;

namespace Dailies.AdventDay3;

using ParseList=List<(string substring, int index)>;
public class PartB
{
    //xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))
    
    /*
    ignoreMul =false
    mul(2,4) is found and parsed...because !ignoreMul, it's accepted
    next find the "don't()" command--ignoreMul=true
    mul(5,5) is found and parsed...because ignoreMul, it's ignored and we advance
    mul(11,8) is found next and parsed...because ignoreMul, it's also ignored and we advance
    next do() is encountered so ignoreMul=false
    finally mul(8,5) is found and parsed....because !ignoreMul, it's also accepted
     */

     
    /// <summary>
    /// Parses a string looking for specific tokens ('do()', 'don't()' and 'mul(' ) and builds an ordered list for
    /// where they are found
    /// </summary>
    /// <param name="input">the input string to scan</param>
    /// <returns>the token/indexof for each token in order</returns>
    public static ParseList ParseInput(string input)
    {
        string[] substrings = { "mul(", "don't()", "do()" };

        // List to store results
        var results = new ParseList();

        // Search for substrings in order
        for (int i = 0; i < input.Length; i++)
        {
            foreach (string substring in substrings)
            {
                if (i + substring.Length <= input.Length && input.Substring(i, substring.Length) == substring)
                {
                    results.Add((substring, i));
                    break; // Move to the next character after finding a match
                }
            }
        }

        return results;
    }

    //attempts to parse the mul command from the input string at the given startIdx (index where the 'm' is found)
    public static int? ParseMult(string memoryString, int startIdx)
    {
        int? leftVal = null;
        int? rightVal = null;

        startIdx += Utils.MUL_TOKEN_LEN;

        leftVal = Utils.GetInteger(memoryString, ref startIdx);
        if (leftVal == null)// we were not able to get an integer--e.g. "mul(borf", so advance to the next entry
        {
            return null;
        }
        if (startIdx>memoryString.Length || memoryString[startIdx++] != ',')
        {
            return null;
        }

        rightVal = Utils.GetInteger(memoryString, ref startIdx);//now get the right value
        if (rightVal == null)// we were not able to get an integer--so advance to the next entry
        {
            return null;
        }

        if (startIdx>memoryString.Length || memoryString[startIdx++] != ')')
        {
            return null;
        }

        //we have a legit command--go ahead and return it
        return (leftVal.Value * rightVal.Value);
    }

    public static int ParseMemoryWithThreeTokens(string memory)
    {
        ParseList parsed = ParseInput(memory);
        int toReturn = 0;
        bool includeMult = true;

        foreach (var token in parsed)
        {
            switch (token.substring)
            {
                case Utils.DO_TOKEN:
                    includeMult = true;
                    break;
                case Utils.DONT_TOKEN:
                    includeMult = false;
                    break;
                case Utils.MUL_TOKEN:
                    if (includeMult)
                    {
                        int? result = ParseMult(memory, token.index);
                        if (result != null)
                        {
                            toReturn+= result.Value;
                        }
                    }
                    break;
                default:
                    //should never reach this!
                    throw new InvalidDataException($"Token: {token.substring} at idx:{token.index} is invalid");
            }
        }


        return toReturn;
    }
}