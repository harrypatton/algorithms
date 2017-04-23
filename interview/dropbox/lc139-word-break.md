Source: https://leetcode.com/problems/word-break/#/description

Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, determine if s can be segmented into a space-separated sequence of one or more dictionary words. You may assume the dictionary does not contain duplicate words.

For example, given
s = "leetcode",
dict = ["leet", "code"].

Return true because "leetcode" can be segmented as "leet code".

`if dict is bigger than string, the second DP is good O(n^2); otherwise the first one is good O(n*m). m is the dictionary count.`

```c#
/*

Naive solution is not easy so we can use DP here.
Use an array dp which length == s.Length + 1. dp[0] = true for no string scenario.
dp[n] = dp[0] && IsWord(1, n) + dp[1] && IsWord(2, n) + ... + dp[n-1] && IsWord(n, n)

time: O(n^2), space: O(n).

*/
public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        if (s == null) return false;
        
        var dp = new bool[s.Length + 1];
        dp[0] = true;
        
        /* first DP
        for(int i = 1; i <= s.Length; i++) {
            for(int j = 0; j < i; j++) {
                if (dp[j] && wordDict.Contains(s.Substring(j, i - j))) {
                    dp[i] = true;
                    break;
                }
            }
        }
        */
        
        // second DP
        for(int i = 0; i < dp.Length; i++) {
            if (dp[i]) {
                // mark the one with matched string 
                foreach(var str in wordDict) {
                    if (str.Length + i <= s.Length && s.Substring(i, str.Length) == str) {
                        dp[i + str.Length] = true;
                    }
                }
            }
        }
        
        return dp[s.Length];
    }
}
```
