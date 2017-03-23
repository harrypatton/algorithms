# LC44. Wildcard Matching
Source: https://leetcode.com/problems/wildcard-matching/#/description

## Learning
1. Not hard question. I can code it up using memorization (DP), but there're a few edge cases that take me a while to fix it. Also the code is not clean.

```csharp
public class Solution {
    public bool IsMatch(string s, string p) {
        if (s == null || p == null) {
            return false;
        }
        
        return IsMatch(s, 0, p, 0, new bool?[s.Length, p.Length]);
    }
    
    public bool IsMatch(string s, int index1, string p, int index2, bool?[,] cache) {        
        if (index1 == s.Length && index2 == p.Length) {
            return true;
        }
        
        if (index1 < s.Length && index2 < p.Length && cache[index1, index2] != null) {
            return cache[index1, index2].Value;
        }
        
        bool isMatched = false;
        int x = index1;
        int y = index2;
        while (index1 < s.Length && index2 < p.Length && p[index2] != '*') {
            if (p[index2] == '?') {
                index1++;
                index2++;
            } else if (p[index2] != '*') {
                if(s[index1] != p[index2]) {
                    isMatched = false;
                    break;
                } else {
                    index1++;
                    index2++;
                }
            }
        }
        
        if (index2 < p.Length && p[index2] == '*') {
            index2++;
            for(int i = index1; i <= s.Length; i++) {
                isMatched = isMatched || IsMatch(s, i, p, index2, cache);
            }
        } else {
            isMatched = (index1 == s.Length && index2 == p.Length);
        }
        
        if (x < s.Length && y < p.Length) {
            cache[x, y] = isMatched;
        }
        
        return isMatched;
    }
}
```
