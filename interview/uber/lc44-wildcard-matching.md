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
## Update - two pointers
Unlike the recursion, this way uses two pointers to move forward. To handle `*`,

1. It starts matching zero letter and move two pointers.
2. Once detect mismatch, go back to the * position and try matching 1 letter.
3. If mismatch again, go back and try 2 letters. 

It nevers try `*` before latest `*`, because,

1. the algorithm always try minimum chars for the `*` and move to next.
2. If latest `*` cannot help and ask previous `*` to match more chars in step 1, 
it means latest `*` and the rest of string will match fewer characters than before. It is not right given that `*` already tried.

anyway, it is a little weird to explain it.

time complexity: O(m * n). m and n are lengths of s and p.

```c#
public class Solution {
    public bool IsMatch(string s, string p) {
        if (s == p) return true;
        else if (s == null || p == null) return false;

        int sIndex = 0;
        int pIndex = 0;
        int starIndex = -1;
        int markIndex = 0;

        while(sIndex < s.Length) { // Note: we don't check p length in big while because of scenario like "aa" => "*"
        	if (pIndex < p.Length && (p[pIndex] == '?' || p[pIndex] == s[sIndex])) {
        		pIndex++;
        		sIndex++;
        	} else if (pIndex < p.Length && p[pIndex] == '*') {
        		starIndex = pIndex;
        		markIndex = sIndex;
        		pIndex++; // it means we use * as empty string.
        	} else if (starIndex != -1) { // we run into a mismatch scenario so fall back to original star.
        		pIndex = starIndex + 1;
        		markIndex++;
        		sIndex = markIndex;	
        	} else { // mismatch. nothing we can do.
        		return false;
        	}
        }

        // reduce remaining '*'
        while(pIndex < p.Length && p[pIndex] == '*') pIndex++;

        return sIndex == s.Length && pIndex == p.Length;
    }
}
```

## Recursion
Easy to understand but even I add a shortcut for consecutive `*` case, it is still time out.

time complexity: O(m^n). 
```
f(m, n) = f(m, n-1) + f(m-1, n -1) + f(m-2, n-1) + f(m-3, n-1) + ... f(1, n-1)
        = f(m, n-2) + 2f(m-1, n-2) + 3f(m-2, n-2) + 4f(m-3, n-2) + .. m*f(1, n-2)
        = ...
        = ... + n^m*f(1, 0)
```

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
