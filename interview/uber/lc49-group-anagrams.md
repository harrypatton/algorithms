source: https://leetcode.com/problems/anagrams/#/description

Given an array of strings, group anagrams together.

For example, given: `["eat", "tea", "tan", "ate", "nat", "bat"]`, 
Return:
```
[
  ["ate", "eat","tea"],
  ["nat","tan"],
  ["bat"]
]
```
Note: All inputs will be in lower-case.

## Analysis
### Solution 1: sorting and grouping
1. create a dictionary <string, List<string>>();
2. foreach string, sort it to be a key, check with dictionary. Add or update a list with the string itself (not key).
3. output the result.

Time complexity: O(m * nlogn). m is the string array size and n is max string length.

In this case, 

1. I don't use the lower-case condition. 
2. We can check if two strings are anagram in O(n). In this solution it is O(nlogn).
3. Because the solution needs groups so it is easy to use dictionary which needs a key. The O(n) comparison doesn't help.

```c#
public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var result = new List<IList<string>>();
        if (strs == null || strs.Length == 0) return result;
        
        var dict = new Dictionary<string, IList<string>>();
        foreach(var str in strs) {
            var chars = str.ToCharArray();
            Array.Sort(chars);
            var key = new string(chars);
            
            if (!dict.ContainsKey(key)) dict[key] = new List<string>();
            dict[key].Add(str);
        }
        
        result.AddRange(dict.Values);        
        return result;
    }
}
```
