# 467 - Unique Substrings in Wraparound String
source: https://leetcode.com/problems/unique-substrings-in-wraparound-string/

**wraparound string**: ``a..za..za..`` (``..`` means b, c, d until y). It has unlimited length.

**Question** - given a string ``s``, return how many unique sub-strings from ``s`` which are also a substring in the warparound string.

To simplify the question, the given string contains only lower-case English letter.

#Idea
1. wraparound string is incremental string. Next char is exactly one bigger than current one. The **exception** is letter 'z'.
2. we can go through the string to find out max incremental substring, and then skip to next letter. When find max incremental substring, all substrings are candidates.
3. Letter ``z`` needs special treatment and should be included in max incremental substring like `xyzabc`.
4. Each individual letter is a candidate by default.
5. Use Hashset to reduce duplicate. (**any other better way?**)
	* we'll get a list of max incremental substrings.
	* if the string doesn't exist in hashset, add it and its substring. (when add substring, we still need to check if duplicate)
	* otherwise, just skip.

**Unfortunately the above solution gets Time Limit Exceeded**. 

#DP Solution
I need help. Cannot figure it out.

**Update**
Here's what I get from the discussion page,

1. All unique strings must end with `a` - `z`. 
2. All unique strings ending with `a` come from the `maximum` incremental string ending with `a`.  Any other incremental string ending with `a` is covered by the `maximum` one. The unique string count is the same as the `maximum` incremental string length.
3. We can scan the whole string and update maximum count for the 26 letters.

Note

1. In the loop, we need to update one letter each time
2. How to remove the duplicate Math.Max ones? See the 2nd code. The loop cover every single element and add an edge condition. 

## Code 1
```CSharp
public class Solution {
    public int FindSubstringInWraproundString(string p) {
        if (p == null || p.Length == 0) {
            return 0;
        }
        
        if (p.Length == 1) {
            return 1;
        }
        
        int[] letterMaxCountList = new int[26];
        int currentMaxCount = 1;
        
        for(int i = 1; i < p.Length; i++) {
            int index = p[i-1] - 'a';
            letterMaxCountList[index] = Math.Max(currentMaxCount, letterMaxCountList[index]);
            
            if (p[i] == p[i - 1] + 1 || (p[i] == 'a' && p[i-1] == 'z')) {
                currentMaxCount ++;
            } else {
                currentMaxCount = 1;
            };            
        }
        
        int lastIndex = p[p.Length - 1] - 'a';
        letterMaxCountList[lastIndex] = Math.Max(currentMaxCount, letterMaxCountList[lastIndex]);
            
        int result = 0;
        foreach(int count in letterMaxCountList) {
            result += count;
        }
        
        return result;
    }
}
```

##Code 2
``` C#
public class Solution {
    public int FindSubstringInWraproundString(string p) {
        if (p == null || p.Length == 0) {
            return 0;
        }
        
        if (p.Length == 1) {
            return 1;
        }
        
        int[] letterMaxCountList = new int[26];
        int currentMaxCount = 0;
        
        for(int i = 0; i < p.Length; i++) {
            if (i > 0 && (p[i] == p[i - 1] + 1 || (p[i] == 'a' && p[i-1] == 'z'))) {
                currentMaxCount++;
            } else {
                currentMaxCount = 1;
            };
            
            int index = p[i] - 'a';
            letterMaxCountList[index] = Math.Max(currentMaxCount, letterMaxCountList[index]);            
        }
            
        int result = 0;
        foreach(int count in letterMaxCountList) {
            result += count;
        }
        
        return result;
    }
}
```
