source: https://leetcode.com/problems/generate-parentheses/#/description

Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

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
### Solution 1 - backtracking
each step, we can choose open or close based on how many remaining.

```c#
public class Solution {
    IList<string> result = new List<string>();
    public IList<string> GenerateParenthesis(int n) {
        GenerateParenthesis(new StringBuilder(), n, n);
        return result;
    }
    
    public void GenerateParenthesis(StringBuilder subResult, int leftOpen, int leftClose) {
        if (leftOpen == 0 && leftClose == 0) {
            result.Add(subResult.ToString());
            return;
        }
        
        if (leftOpen > 0) {
            GenerateParenthesis(subResult.Append("("), leftOpen - 1, leftClose);
            subResult.Length--;
        }
        
        if (leftOpen < leftClose) {
            GenerateParenthesis(subResult.Append(")"), leftOpen, leftClose - 1);
            subResult.Length--;
        }
    }
}
```

### Solution 2 - DP solution
f(n) could be composition of the following results,
```
() + f(n-1)
(f(1)) + f(n-2)
(f(2)) + f(n-3)
f(f(n-2)) + ()
f(n) = f(n-1) + 2 * (f(n-2) + f(n-3) + f(n-4) + ... f(n-2))
     = f(n-1) + 2 * (f(n-2) + 2 * (f(n-3) + f(n-4) + ..))
     = 2*2*(f(n-3) + f(n-4) + ...)
     = O(2^n)
```

Use an array to save f(0), f(1), ... f(n) solutions. Each one is O(n) and total time complexity is O(n^2).
wait - it is probably still O(2^n) because we have so many results. result(1) + result(n-1) is not a O(1) because both are collections.

```c#
public class Solution {    
    public IList<string> GenerateParenthesis_Iterative(int n) {
        var dict = new Dictionary<int, IList<string>>();
        dict[0] = new List<string>();
        dict[0].Add("");
        
        if (dict.ContainsKey(n)) return dict[n];
        
        for(int i = 1; i <= n; i++) {
            var result = new List<string>();
            for(int j = 0; j < i; j++) {
                var left = dict[j];
                var right = dict[i - j - 1];
                foreach(var leftStr in left) {
                    foreach(var rightStr in right)
                        result.Add("(" + leftStr + ")" + rightStr);
                }
            }
            dict[i] = result;
        }
        
        return dict[n];
    }
}
```
### Time complexity
* Naive solution - generate all combination 2^n, and check if each is valid (another n), so total is O(n * 2 ^n).
* backtracking or DP solution: O(2^n) because they know what valid combinations are.
