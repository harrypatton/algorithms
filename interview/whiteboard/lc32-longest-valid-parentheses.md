Source: https://leetcode.com/problems/longest-valid-parentheses/#/description

Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses **substring**.

For "(()", the longest valid parentheses substring is "()", which has length = 2.

Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4.

## Analysis
**Always double check it is subarray or sub-sequence.**

## Naive Solution
Just check every possible substring. O(n*2^n). 

```c#
public class Solution {
    public int LongestValidParentheses(string s) {
        // start from max len so we can quit early.
        for(int len = s.Length; len >= 1; len--) {
            for(int i = 0; i < s.Length; i++) {
                if (i + len - 1 < s.Length) { // valid substring
                    if(IsValid(s.Substring(i, len))) return len;
                }
            }
        }
        
        return 0;
    }
    
    public bool IsValid(string s) {
        int openCount = 0;
        int closeCount = 0;
        
        foreach(var c in s) {
            if (c == '(') openCount++;
            if (c == ')') closeCount++;
            if (closeCount > openCount) return false;
        }
        
        return openCount == closeCount;
    }
}
```
