Source: https://leetcode.com/problems/word-pattern/#/description

## Analysis
* Use hash table to track mapping relation.
* Use hashset to make sure it is bijection so multiple letters cannot map to the same string.
* We may use List to replace HashTable given all strings are lower-case.

```c#
public class Solution {
    public bool WordPattern(string pattern, string str) {
        if (pattern == null || str == null) return false;
        var strs = str.Split(' ');
        if (pattern.Length != strs.Length) return false;
        
        var dict = new Dictionary<char, string>();
        var hashset = new HashSet<string>();
        
        for(int i = 0; i < pattern.Length; i++) {
            if (dict.ContainsKey(pattern[i])) {
                if (dict[pattern[i]] != strs[i]) return false;
            } else {
                if(hashset.Contains(strs[i])) return false;
                dict[pattern[i]] = strs[i];
                hashset.Add(strs[i]);
            }
        }
        
        return true;
    }
}
```
