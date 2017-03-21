# LC22 - Generate Parentheses
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses. [Source](https://leetcode.com/problems/generate-parentheses/#/description)

For example, given n = 3, a solution set is:
```
[
  "((()))",
  "(()())",
  "(())()",
  "()(())",
  "()()()"
]
```

## Analysis
1. There're two ways to do the work. 
	* Backtracking - we define two variables openCount and closeCount. Init value is n. 
		* When openCount > 0, we can add an open bracket to the result and then call the recursion method. 
		* When above statement finishes, we can continue to check if openCount > closeCount because we can also add close bracket as well.
		* Remember backtracking is to enumerate all possible results.
	* DP solution. start with a pair () as left part and the rest as right part. Inside left part, it could be [0 .. n-1] pairs. so the formula is `f(n) = (f(0)) f(n-1), (f(1)) f(n-2), ..., (f(n-1))`

**Update**: base condition is very important. I missed the base when n == 0 in first coding so the whole result is wrong. Be careful:).

```csharp
public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var result = new List<string>();
        if (n == 0) {
            result.Add("");
        } else {
            for (int i = 0; i < n; i++) {
                var l1 = GenerateParenthesis(i);
                var l2 = GenerateParenthesis(n - 1 - i);
                
                foreach(var str1 in l1) {
                    foreach(var str2 in l2) {
                        result.Add("(" + str1 + ")" + str2);
                    }
                }
            }
        }
        
        return result;
    }
}
```
