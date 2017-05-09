Source: https://leetcode.com/problems/maximum-size-subarray-sum-equals-k/#/description

Given an array nums and a target value `k`, find the maximum length of a subarray that sums to `k`. If there isn't one, return 0 instead.

Note: the sum of the entire nums array is guaranteed to fit within the 32-bit signed integer range.

Example 1:
```
Given nums = [1, -1, 5, -2, 3], k = 3,
return 4. (because the subarray [1, -1, 5, -2] sums to 3 and is the longest)
```

Example 2:
```
Given nums = [-2, -1, 2, 1], k = 1,
return 2. (because the subarray [-1, 2] sums to 1 and is the longest)
```

## Analysis
* Use a hashtable to save `<sum, index>`. 
* When sum appears again, we don't update the value because previous one can give us bigger length.
* base: key == zero. let's use value -1. 
* need to calculate accumulative sum during th iteration

## Code

```c#
public class Solution {    
    public int MaxSubArrayLen(int[] nums, int k) {
        if (nums == null) return 0;
        
        int sum = 0;
        int max = 0;

        var dict = new Dictionary<int, int>();
        dict.Add(0, -1);

        for(int i = 0; i < nums.Length; i++) {
        	sum += nums[i];
        	if(dict.ContainsKey(sum - k)) {
        		max = Math.Max(max, i - dict[sum - k]);
        	}

        	if (!dict.ContainsKey(sum)) dict[sum] = i;
        }

        return max;
    }    
}
```
