source: https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/#/description

Given a string, find the length of the longest substring `T` that contains at most `k` distinct characters.

For example, Given `s = “eceba”` and `k = 2`,

`T` is `"ece"` which its length is 3.

## Analysis
* naive solution: there're total n^2 substring. For each substring, use hashset to check how many unique ones.
  * total time complexity is O(n^3)
* optimized solution: use two pointers with a hash table (dictionary)
  * two pointers. start and end.
  * add end to dictionary => check size. 
    * if size <= k, update max;
    * otherwise; repeat until size <= k: remove the element on start position, move start forward. need to check start <= end.
    * why not update max in step b? because we must have the longest one in step a. Step b can have at most the same length as b.
  * time complexity: O(n). space O(n) - n is distinct char.

```c#
public class Solution {
    public int LengthOfLongestSubstringKDistinct(string s, int k) {
        if (s == null || k <= 0) return 0;

        var dict = new Dictionary<char, int>();
        int start = 0;
        int end = 0;
        int result = 0;

        while(start <= end && end < s.Length) {
        	var c = s[end];
        	end++;
        	dict[c] = dict.ContainsKey(c) ? dict[c] + 1 : 1;
        	if (dict.Count <= k) {
        		result = Math.Max(result, end - start);        		
        	} else {
        		while(start < end && dict.Count > k) {
        			var removedChar = s[start];
        			dict[removedChar] -= 1;
        			if (dict[removedChar] == 0) dict.Remove(removedChar);
        			start++;
        		}
        	}
        }

        return result;
    }
}
```
