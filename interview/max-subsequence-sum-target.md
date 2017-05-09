I misunderstood the question and calculate subsequence for the issue.

It can be either DP or recursion with memory cache.

```c#
/*
Given an array nums and a target value k, find the maximum length of a subarray that sums to k.
If there isn't one, return 0 instead.

A DP problem.
1. f(n, k) = Math.Max(1 + f(n-1, k - nums[n]), f(n-1, k));
    it shows the result depends on previous row result.
2. if k is out of range [negative_sum, positive_sum], return false.
3. How big is the column count? k-positive_sum, k - negative_sum
 */
public class Solution {
    public struct CacheKey {
        public int pos;
        public int k;
    }
    
    public Dictionary<CacheKey, int> cache = new Dictionary<CacheKey, int>();
    
    public int MaxSubArrayLen(int[] nums, int k) {
        return MaxSubArrayLen(nums, 0, k);
    }
    
    public int MaxSubArrayLen(int[] nums, int pos, int k) {
        if (nums == null || nums.Length == 0) return 0;        
        if (pos >= nums.Length) return 0;
               
        var key = new CacheKey();
        key.pos = pos;
        key.k = k;
        
        if (cache.ContainsKey(key)) return cache[key];

        int result = 0;

        // case 1
        if (nums[pos] == k) result = 1;

        // case 2
        var num1 = MaxSubArrayLen(nums, pos + 1, k - nums[pos]);
        if (num1 != 0) result = 1 + num1;

        // case 3
        var num2 = MaxSubArrayLen(nums, pos + 1, k);
        if (num2 != 0) result = Math.Max(result, num2);

        cache[key] = result;
        
        return result;
    }
}
```
