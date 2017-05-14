source: https://leetcode.com/problems/repeated-substring-pattern/#/description

Given a non-empty string check if it can be constructed by taking a substring of it and 
appending multiple copies of the substring together. You may assume the given string consists of 
lowercase English letters only and its length will not exceed 10000.

Example 1:
```
Input: "abab"
Output: True
Explanation: It's the substring "ab" twice.
```

Example 2:
```
Input: "aba"
Output: False
```

Example 3:
```
Input: "abcabcabcabc"
Output: True
Explanation: It's the substring "abc" four times. (And the substring "abcabc" twice.)
```

## Analysis
When look at lowercase one, I always think of 26-element array or hash table; I thought I can get each letter count
and figure out the substring length. It is wrong. It uses a brutal force method to do the work.

## Brutal Force
1. A substring length could be from 2 to string_length / 2. 
2. If not divided, we can ignore that number. 
3. How many divisor do we have? `len = a * b`. Assume `a` is the smallest one, it is true that `a<=sqrt(len)`. so there're at most `2 * sqrt(len)` divisors. 
For each one, time complexity is O(n) so total is O(n^1.5).

```c#
public class Solution {
    public bool RepeatedSubstringPattern(string s) {
        if(s == null || s.Length <= 1) return false;

        for(int len = 1; len <= s.Length / 2; len++) {
        	if (s.Length % len != 0) continue;

        	// one time match O(n)
        	bool misMatch = false;        	
	        for(int i = len; i < s.Length; i += len) {	        	
	        	for(int j = i; j < i + len; j++) {
	        		if (s[j] != s[j-i]) {
	        			misMatch = true;
	        			break;
	        		}
	        	}

	        	if (misMatch) break;
	        }

	        if (!misMatch) return true;
        }

        return false;
    }
}
```

## KMP
It is hard to understand. Add a link here: http://mp.weixin.qq.com/s/V_6aPHt3t0tsvKRPCv36uA
