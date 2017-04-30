Source: https://leetcode.com/problems/remove-invalid-parentheses/#/description

Remove the minimum number of invalid parentheses in order to make the input string valid. Return all possible results.

Note: The input string may contain letters other than the parentheses ( and ).

Examples:
```
"()())()" -> ["()()()", "(())()"]
"(a)())()" -> ["(a)()()", "(a())()"]
")(" -> [""]
")(f" -> ["f"]
```

```c#
/*
this is a hard level question. 
after reading the question, I don't have any clue how to solve it.

1. It seems easy to calculate max valid parentheses.
    a. iterate the string and track open and close count. when close > open, we need to eliminate one.
2. After that, we can use backtracking to get all possible result.
    a. use two variables to track remaining open and close count. always remaining_open <= remaining_close.
    b. use backtracking and track open and close count. As long as it is valid and meet the max count, it is the result.
*/
public class Solution {
    private HashSet<string> result = new HashSet<string>();
    
    public IList<string> RemoveInvalidParentheses(string s) {
        if (s == null) return result.ToList();
        
        int max = GetMaxPairCount(s);
        Traverse(s, max, max, "");
        
        return result.ToList();
    }
    
    public void Traverse(string s, int open, int close, string match) {
        if (open > close) return; //invalid result.
        
        if(open == 0 && close == 0 && s == string.Empty) {            
            result.Add(match); 
            return;
        }
        
        if (s != string.Empty) {
            if (s[0] == '(') {
                if (open > 0) Traverse(s.Substring(1), open - 1, close, match + "(");
                Traverse(s.Substring(1), open, close, match);
            } else if (s[0] == ')') {
                if (open < close) Traverse(s.Substring(1), open, close - 1, match + ")");
                Traverse(s.Substring(1), open, close, match);
            } else {
                Traverse(s.Substring(1), open, close, match + s[0]);
            }

        }
    }
    
    public int GetMaxPairCount(string s) {
        int openCount = 0;
        int closeCount = 0;
        
        foreach(var c in s) {
            if (c == '(') {
                openCount++;
            } else if (c == ')' && openCount > closeCount) {
                closeCount++;
            }
        }
        
        return closeCount;
    }
}
```
