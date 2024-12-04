namespace Dailies.AdventDay4;

using WordList = List<List<char>>;
public class PartB
{
	/// <summary>
	/// Verify if the A located at xA,yA has cross M and A
	/// </summary>
	/// <param name="wl">word list to check</param>
	/// <param name="xA">x index for the 'A' char</param>
	/// <param name="yA">y index for the 'A' char</param>
	/// <param name="maxX">max horizontal for the wordlist (QOL param)</param>
	/// <param name="maxY">max vert for the wordlist (QOL param)</param>
	/// <returns>true if we find the X-MAS pattern</returns>
	private static bool FindMAS(WordList wl, int xA, int yA, int maxX, int maxY)
	{
		//first check to make sure that A isn't located on the edge of the wordlist
		//  (this is a fail, and also serves as an OOB check!
		if (xA == 0 || xA+1 == maxX || yA == 0 || yA+1 == maxY)
		{
			return false;
		}
        
/*
M		M		M	X	Y	S	X	Y
	A				-1	-1		-1	1
S      S			1	-1		1	1
*/
		if (wl[yA - 1][xA - 1] == 'M' &&
		    wl[yA - 1][xA + 1] == 'M' &&
		    wl[yA + 1][xA - 1] == 'S' &&
		    wl[yA + 1][xA + 1] == 'S' 
		    )
		{
			return true;
		}
/*
S		M		M	X	Y	S	X	Y
	A				1	-1		-1	-1
S		M			1	1		-1	1
*/
		if (wl[yA - 1][xA + 1] == 'M' &&
		    wl[yA + 1][xA + 1] == 'M' &&
		    wl[yA - 1][xA - 1] == 'S' &&
		    wl[yA + 1][xA - 1] == 'S' 
		   )
		{
			return true;
		}
/*
S		S		M	X	Y	S	X	Y
	A				-1	1		-1	-1
M		M			1	1		1	-1
*/
		if (wl[yA + 1][xA - 1] == 'M' &&
		    wl[yA + 1][xA + 1] == 'M' &&
		    wl[yA - 1][xA - 1] == 'S' &&
		    wl[yA - 1][xA + 1] == 'S' 
		   )
		{
			return true;
		}
/*
M		S		M	X	Y	S	X	Y
	A				-1	-1		1	-1
M		S			-1	1		1	1
 */
		if (wl[yA - 1][xA - 1] == 'M' &&
		    wl[yA + 1][xA - 1] == 'M' &&
		    wl[yA - 1][xA + 1] == 'S' &&
		    wl[yA + 1][xA + 1] == 'S' 
		   )
		{
			return true;
		}

		return false;
	}
    public static int Solution(string rawInput)
    {
        int sequencCt = 0;
        WordList wl = Utils.ParseRawData(rawInput);

        int maxY = wl.Count;
        int maxX = wl[0].Count;

        /*
         Looking for something like
         M M
          A
         S S

         Key element is the "A" is the center of a 3x3 grid.  Once we find that
         //then there are 4 possible matches for M and S
         arranged in the corners of the 3x3 grid
         */
        
        for (int y = 0; y < maxY; ++y)
        {
	        for (int x = 0; x < maxX; ++x)
	        {
		        if (wl[y][x] == 'A')
		        {
			        sequencCt += FindMAS(wl, x, y, maxX, maxY) ? 1 : 0;
		        }
	        }
        }
        
        return sequencCt;
    }
}