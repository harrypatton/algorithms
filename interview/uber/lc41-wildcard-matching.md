Source: https://leetcode.com/problems/wildcard-matching/#/solutions

Implement wildcard pattern matching with support for `?` and `*`.

`?` Matches any single character.
`*` Matches any sequence of characters (including the empty sequence).

The matching should cover the entire input string (not partial).

The function prototype should be: `bool isMatch(const char *s, const char *p)`

Some examples:
```
isMatch("aa","a") → false
isMatch("aa","aa") → true
isMatch("aaa","aa") → false
isMatch("aa", "*") → true
isMatch("aa", "a*") → true
isMatch("ab", "?*") → true
isMatch("aab", "c*a*b") → false
```

## Recursion
Easy to understand but even I add a shortcut for consecutive `*` case, it is still time out.

```c#
public class Solution {
    public bool IsMatch(string s, string p) {
        if (s == p) return true;
        else if (s == null || p == null) return false;

        int s1 = 0; int p1 = 0;
        
        while(s1 < s.Length && p1 < p.Length) {
            if(p[p1] == '?' || s[s1] == p[p1]) {
                s1++; p1++;
            } else if (p[p1] == '*') {
            	// move to next * to accelerate
            	while(p1+1 < p.Length && p[p1 + 1] == '*') p1++;
                for(int i = s1; i <= s.Length; i++) {
                    if (IsMatch(s.Substring(i), p.Substring(p1 + 1))) return true;
                }
                return false;
            } else return false; // no match
        }
        
        // string completes. check remaining letters in p
        while(p1 < p.Length && p[p1] == '*') p1++;

        return s1 == s.Length && p1 == p.Length;
    }
}
```
