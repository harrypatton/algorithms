# LC301 - Remove Invalid Parentheses
Source: https://leetcode.com/problems/remove-invalid-parentheses/#/description

Remove the minimum number of invalid parentheses in order to make the input string valid. Return all possible results.

Note: The input string may contain letters other than the parentheses ( and ).

Examples:
```
"()())()" -> ["()()()", "(())()"]
"(a)())()" -> ["(a)()()", "(a())()"]
")(" -> [""]
```

## Analysis
1. when openCount >= closeCount, we can continue; otherwise we have to ignore the new close char.
2. The following code is just to return one result. The tricky part is how to calculate the last part when openCount > closeCount.

```csharp
    public string LongestValidParentheses(string s) {
        var result = new List<char>();
        int openCount = 0;
        int closeCount = 0;

        foreach (char c in s) {
            if (c == '(') {
                result.Add(c);
                openCount++;
            } else if (c == ')') {
                if (openCount > closeCount) {
                    result.Add(c);
                    closeCount++;
                }
            } else {
                result.Add(c);
            }
        }

        if (openCount > closeCount) {
            int count = openCount - closeCount;
            int index = result.Count - 1;
            while (count > 0 && index >= 0) {
                if (result[index] == '(') {
                    count--;
                    result.RemoveAt(index);
                }

                index--;
            }
        }

        return new string(result.ToArray());
    }
```
