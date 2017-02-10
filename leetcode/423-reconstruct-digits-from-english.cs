public class Solution
{
    public string OriginalDigits(string s)
    {
        if (s == null || s == string.Empty)
        {
            return string.Empty;
        }

        int[] charCount = new int[26];
        bool[] numUsed = new bool[10];

        foreach (var c in s)
        {
            charCount[c - 'a']++;
        }

        var result = OriginalDigits(charCount, numUsed);

        char[] resultChar = result.ToArray();
        Array.Sort(resultChar);
        return new string(resultChar);
    }

    public string OriginalDigits(int[] charCount, bool[] numUsed)
    {
        for (int i = 0; i < charCount.Length; i++)
        {
            if (charCount[i] < 0)
            {
                return string.Empty;
            }
        }

        for (int i = 0; i < numUsed.Length; i++)
        {
            if (!numUsed[i])
            {
                // we'll try this number so two conditions

                // condition #1 - the result has this number
                RemoveCharCount(charCount, i);

                // found it
                if (charCount.All(item => item == 0))
                {
                    AddCharCount(charCount, i);
                    return i.ToString();
                }

                // the result has this number and other numbers
                string tempResult = OriginalDigits(charCount, numUsed);

                if (tempResult != string.Empty)
                {
                    AddCharCount(charCount, i);
                    return tempResult + i;
                }

                // condition #2 - the result doesn't have this number
                
                // set flag
                numUsed[i] = true;

                // restore chars first
                AddCharCount(charCount, i);
                tempResult = OriginalDigits(charCount, numUsed);

                // restore the flag
                numUsed[i] = false;

                if (tempResult != string.Empty)
                {
                    return tempResult;
                }

                return string.Empty;
            }
        }

        return string.Empty;
    }

    public void AddCharCount(int[] charCount, int number)
    {
        foreach (var c in numStrings[number])
        {
            charCount[c - 'a']++;
        }
    }

    public void RemoveCharCount(int[] charCount, int number)
    {
        foreach (var c in numStrings[number])
        {
            charCount[c - 'a']--;
        }
    }

    string[] numStrings = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
}
