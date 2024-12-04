namespace Dailies.AdventDay4;

using WordList = List<List<char>>;

public static class PartA
{
    private static bool FindWord(WordList wl,int x, int y, int xInc, int yInc, string word, int wordIdx)
    {
        //See if the letter at X and Y matches the letter we care about
        if (wl[y][x] != word[wordIdx])
        {
            return false;
        }

        //advance to the next letter
        ++wordIdx;
        if (wordIdx == word.Length)//no more letters to check!!
        {
            return true;
        }

        //advance Y and see if we are OOB
        y += yInc;
        if (y < 0 || y == wl.Count)
        {
            return false;
        }

        //Check the OOB for X...
        //technically I could extract the xMax and yMax on the word grid as part of my parse
        //but this is slightly more flexible (ragged array)?
        List<char> row = wl[y];
        x += xInc;
        if (x < 0 || x == row.Count)
        {
            return false;
        }

        return FindWord(wl, x, y, xInc, yInc, word, wordIdx);
    }
    
    public static int Solution(string rawData, string wordToFind="XMAS")
    {
        int xmasCt = 0;
        WordList wl = Utils.ParseRawData(rawData);
        //looking for x m a s 

        for (int y = 0; y < wl.Count; ++y)
        {
            List<char> row = wl[y];
            for (int x = 0; x < row.Count; ++x)
            {
                if (wl[y][x] == wordToFind[0])//e.g "x" in xmas
                {
                    /*
                       now that we have a starting point for the letter, we need to cycle 
                       through each direction...incrementers will be by each of these:
                      (-1,-1) (0,-1) (1,-1)
                      (-1, 0) (x,y) (1,0)
                      (-1, 1) (0,1) (1,1)

                            samxmas
                              mmm
                             a a a
                            s  s  s
                    */

                    xmasCt += FindWord(wl, x, y, -1, -1, wordToFind, 0) ? 1 : 0;
                    xmasCt += FindWord(wl, x, y, -1, 0, wordToFind, 0) ? 1 : 0;
                    xmasCt += FindWord(wl, x, y, -1, 1, wordToFind, 0) ? 1 : 0;

                    xmasCt += FindWord(wl, x, y, 0, -1, wordToFind, 0) ? 1 : 0;
                    xmasCt += FindWord(wl, x, y, 0, 1, wordToFind, 0) ? 1 : 0;

                    xmasCt += FindWord(wl, x, y, 1, -1, wordToFind, 0) ? 1 : 0;
                    xmasCt += FindWord(wl, x, y, 1, 0, wordToFind, 0) ? 1 : 0;
                    xmasCt += FindWord(wl, x, y, 1, 1, wordToFind, 0) ? 1 : 0;
                }

            }
        }


        return xmasCt;
    }
    
}