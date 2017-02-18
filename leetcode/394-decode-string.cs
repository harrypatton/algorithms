public class Solution
{
    public string DecodeString(string s)
    {
        if (s == null || s == string.Empty)
        {
            return s;
        }

        var charStack = new Stack<char>();
        var numStack = new Stack<char>();
        var result = new StringBuilder();

        foreach (var c in s)
        {
            if (c == '[')
            { // open bracket
                charStack.Push(c);
                numStack.Push(c);
            }
            else if (c >= '0' && c <= '9')
            { // number
                numStack.Push(c);
            }
            else if (c == ']')
            { // do the calculation
                UpdateResult(result, charStack, numStack);
            }
            else
            { // it is a letter to be repetitive
                charStack.Push(c);
            }
        }

        if (charStack.Any())
        {
            UpdateResult(result, charStack, numStack);
        }

        return result.ToString();
    }

    private void UpdateResult(StringBuilder result, Stack<char> charStack, Stack<char> numStack)
    {
        var singleString = GetChars(charStack);
        if (charStack.Any())
        {
            if (charStack.Peek() != '[')
            {
                throw new ApplicationException("the char stack should have '[' on top.");
            }

            charStack.Pop();
        }

        var num = GetRepeatNum(numStack);

        var repetitiveString = new StringBuilder();

        for (int i = 0; i < num; i++)
        {
            repetitiveString.Append(singleString);
        }

        // push back the result if char stack is not empty.
        if (charStack.Any())
        {
            for (int i = 0; i < repetitiveString.Length; i++)
            {
                charStack.Push(repetitiveString[i]);
            }
        }
        else
        {
            result.Append(repetitiveString.ToString());
        }
    }

    private string GetChars(Stack<char> charStack)
    {
        var charList = new StringBuilder();

        // find chars from char stack
        while (charStack.Any() && charStack.Peek() != '[')
        {
            charList.Append(charStack.Pop().ToString());
        }

        var chars = charList.ToString().ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    private int GetRepeatNum(Stack<char> numStack)
    {
        if (!numStack.Any())
        {
            return 1;
        }

        if (numStack.Peek() != '[')
        {
            throw new ApplicationException("the num stack should have '[' on top.");
        }

        numStack.Pop();

        string valueString = GetChars(numStack);

        int value = 0;
        foreach (var c in valueString)
        {
            value = value * 10 + (c - '0');
        }

        return value;
    }
}
