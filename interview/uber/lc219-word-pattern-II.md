source: https://leetcode.com/problems/word-pattern-ii/#/description

Given a pattern and a string str, find if str follows the same pattern.

Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty substring in str.

Examples:
```
pattern = "abab", str = "redblueredblue" should return true.
pattern = "aaaa", str = "asdasdasdasd" should return true.
pattern = "aabb", str = "xyzabcxzyabc" should return false.
```

Notes: You may assume both pattern and str contains only lowercase letters.

## Analysis
pattern match - **it requires bijection**. A letter has only one match. `Multiple letters cannot map to the same string.
That's why we need a HashSet for the check.`

1. use backtracking.
2. save a dictionary (global) to save the mapping.
3. start from pattern. 
    a. the first letter could map to substring(0,1), substring(0, 2) ... str.
    b. add the map to dictionary and recursive call the rest of them.
    c. if the first letter has a mapping in dictionary, try to compare with the str. 
    d. whenever failed to match, try next possibility. 
4. be careful about the edge case.

### Complexity
This is from the discussion page.

And, I think for this kind of question, str.length should be much larger than pattern.length;
```
In the shared code, the for-loop works on "str", not pattern.
So, I think T(n) = [ T(1)+T(n-1) ] + [T(2)+T(n-2)] + ......
T(n-1) = [T(1)+T(n-2)] + ....
So, T(n) = O(2^n);
```

```c#
public class Solution {
    private Dictionary<char, string> dict = new Dictionary<char, string>();
    private HashSet<string> values = new HashSet<string>();
    
    public bool WordPatternMatch(string pattern, string str) {
        if(pattern == null && str == null) return true;
        else if (pattern == null || str == null) return false;
        else if (pattern == "" && str == "") return true;
        else if (pattern == "" || str == "") return false;
        
        var key = pattern[0];
        if (dict.ContainsKey(key)) {
            if(str.StartsWith(dict[key])) {
                return WordPatternMatch(pattern.Substring(1), str.Substring(dict[key].Length));
            } else {
                return false;
            }
        } else {
            for(int i = 0; i < str.Length; i++) {
                var value = str.Substring(0, i + 1);
                if (values.Contains(value)) continue;
                dict[key] = value;
                values.Add(value);
                var match = WordPatternMatch(pattern.Substring(1), str.Substring(i + 1));
                dict.Remove(key);
                values.Remove(value);
                if (match) return true;
            }
        }
        
        return false;
    }
}
```
