Source: https://leetcode.com/problems/word-pattern/#/description

Given a pattern and a string str, find if str follows the same pattern.

Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in str.

Examples:
```
pattern = "abba", str = "dog cat cat dog" should return true.
pattern = "abba", str = "dog cat cat fish" should return false.
pattern = "aaaa", str = "dog cat cat dog" should return false.
pattern = "abba", str = "dog dog dog dog" should return false.
```
Notes:
You may assume pattern contains only lowercase letters, and str contains lowercase letters separated by a single space.

```c#
/*
use a hash table to store the mapping;
iterate over both to check if they match.

1. split str to be a string array. check length first.
2. if the letter is not in mapping, store it.
3. if it is in mapping, check if they match.

Remember it is bijection so two letters cannot map to the same string.
*/
public class Solution {
    public bool WordPattern(string pattern, string str) {
        if (pattern == null || str == null) return false;        
        var strings = str.Split(' ');
        if(pattern.Length != strings.Length) return false;
        
        var dict = new Dictionary<char, string>();
        var hashSet = new HashSet<string>();
        for(int i = 0; i < pattern.Length; i++) {
            if(!dict.ContainsKey(pattern[i])) {
                // bijection check
                if (hashSet.Contains(strings[i])) return false;
                dict[pattern[i]] = strings[i];
                hashSet.Add(strings[i]);
            } else if (dict[pattern[i]] != strings[i]) {
                return false;
            }
        }
        
        return true;
    }
}
```
