# LC5 - Longest Palindrom Substring
*Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.* [Source](https://leetcode.com/problems/longest-palindromic-substring/#/description)

## Analysis
1. It is easy for me to find DP and iterative solution. Both are time O(n^2). DP needs space O(n^2), but iterative solution just needs O(1). 
2. I know wiki shows a linear solution but it is too complicated.

## Whiteboard
1. I can write the algorithm but get a little bit stuck when think about edge cases. I realize the normal code can cover all edge cases. Before that, I still wrote some code and then erased later. 
2. In whiteboard coding, I should start with normal cases but leave with some spaces so I can add code for edge cases if necessary later. It would help me to focus on main scenario and also have spaces to think about edge cases later.

**Update**: whiteboard coding quality is high. Just miss the return statement. One time pass.

LeetCode also has an article for this question: https://leetcode.com/articles/longest-palindromic-substring/

```c#
public class Solution {
    public string LongestPalindrome(string s) {
        if (s == null || s.Length == 0) {
            return s;
        }
        
        var result = "";
        for(int i = 0; i < s.Length; i++) {
            result = GetLongest(s, result, i - 1, i +1);
            result = GetLongest(s, result, i, i +1);
        }
        
        return result;        
    }
    
    public string GetLongest(string s, string result, int start, int end) {
        while (start >= 0 && end < s.Length && s[start] == s[end]) {
            start--;
            end++;
        }
        
        if (end - start - 1 > result.Length) {
            result = s.Substring(start+1, end - start - 1);
        }
        
        return result;
    }
}

```
