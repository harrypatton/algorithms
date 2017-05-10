Source: https://leetcode.com/problems/longest-valid-parentheses/#/description

Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses **substring**.

For "(()", the longest valid parentheses substring is "()", which has length = 2.

Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4.

## Analysis
**Always double check it is subarray or sub-sequence.**

## DP solution
`f(i)` means the longest valid string ending with element `i`. Check source code below for the formula.

```c#
public class Solution {
    public int LongestValidParentheses(string s) {
        int max = 0;
        if (s == null || s.Length < 2) return max;
        var result = new int[s.Length];
        
        for(int i = 1; i < s.Length; i++) {
            if (s[i] == '(') result[i] = 0;
            else if (s[i] == ')') {
                if (i - 1 >= 0 && s[i-1] == '(') {
                    result[i] = 2;
                    if (i - 2 >= 0) result[i] += result[i-2];
                } else if (i - 1 >= 0 && s[i-1] == ')') {
                    var start = i - 1 - result[i-1];
                    if (start >= 0 && s[start] == '(') {
                        result[i] = 2 + result[i-1];
                        if (start - 1 >= 0) result[i] += result[start - 1];
                    } else result[i] = 0;
                }
            }
            
            max = Math.Max(max, result[i]);
        }
        
        return max;
    }
}
```

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
