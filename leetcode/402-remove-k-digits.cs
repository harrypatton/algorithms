public class Solution
{
    public string RemoveKdigits(string num, int k)
    {
        if (num == null || num.Length == k)
        {
            return "0";
        }

        var stack = new char[num.Length];
        int endIndex = -1;
        int counter = k;

        for(int i = 0; i < num.Length; i++)
        {
            while(endIndex >= 0 && stack[endIndex] > num[i] && counter > 0)
            {
                // pop the element
                endIndex--;
                counter--;
            }

            // push the element
            stack[++endIndex] = num[i];
        }
        
        endIndex -= counter;
        int startIndex = 0;

        // remove leading zero
        while(startIndex < stack.Length && stack[startIndex] == '0')
        {
            startIndex++;
        }

        string result = new string(stack, startIndex, endIndex - startIndex + 1);
        return result == string.Empty ? "0" : result;
    }
}
