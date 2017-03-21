# LC516. Longest Palindromic Subsequence
Given a string s, find the longest palindromic subsequence's length in s. You may assume that the maximum length of s is 1000. [Source](https://leetcode.com/problems/longest-palindromic-subsequence/#/description)

Example 1:
```
Input: "bbbab"
Output: 4
One possible longest palindromic subsequence is "bbbb".
```

Example 2:
```
Input:  "cbbd"
Output: 2
One possible longest palindromic subsequence is "bb".
```

## Analysis
1. DP problem - how to find sub-problem formula. Say f(x, y) means the result for substring [x, y]. There're 3 possible results and we choose the max one
	* `f(x+1, y - 1) + (if element[x] == element[y], add 1; otherwise 0)`
	* `f(x, y -1)`
	* `f(x+1, y)`
2. It uses diagonal calculation so be careful. **Update**: we can scan the last line and then above line to avoid this diagonal calculation. check discussion page. very smart. 

**Update**

1. It took me 20 minutes to figure out the DP solution because of the tricky sub-problem.
2. When two elements match, the number adds 2 instead of 1. I made this mistake in the first coding. What a shame!

```csharp
public class Solution {
    public int LongestPalindromeSubseq(string s) {
        if (s == null || s.Length == 0) {
            return 0;
        }
        
        var cache = new int[s.Length, s.Length];
        for(int i = 0; i< s.Length; i++) {
            int x = 0;
            int y = i;
            
            while(y < s.Length) {
                if (x == y) {
                    cache[x, y] = 1;
                } else if (x < y) {
                    var result = cache[x+1, y-1] + (s[x] == s[y] ? 2 : 0);
                    cache[x, y] = Math.Max(result, Math.Max(cache[x + 1, y], cache[x, y - 1]));
                }
                
                x++;
                y++;
            }
        }
        
        return cache[0, s.Length - 1];
    }
}
```
