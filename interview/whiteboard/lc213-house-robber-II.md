source: https://leetcode.com/problems/house-robber-ii/#/solutions

This time, all houses at this place are arranged `in a circle`. 
That means `the first house is the neighbor of the last one.` 
Meanwhile, the security system for these houses remain the same as for those in the previous street.


```c#
/*
DP problem. 
1. use a variable to track max one.
2. f(n) means the max one until current house (inclusive).
    f(n) = Max(f(n-1), nums[n] + f(n-2));
3. start with f(0) and f(1) to avoid edge cases.
*/
public class Solution {
    public int Rob(int[] nums) {
        if (nums == null || nums.Length <= 0) {
            return 0;
        } else if (nums.Length == 1) {
            return nums[0];
        }
        
        return Math.Max(Rob(nums, 0, nums.Length - 2), Rob(nums, 1, nums.Length - 1));
    }
    
    public int Rob(int[] nums, int start, int end) {
        if (nums == null || start > end) {
            return 0;
        } else if (start == end) {
            return nums[start];
        }
        
        int house2 = nums[start];
        int house1 = Math.Max(house2, nums[start + 1]);        
        
        for(int i = start + 2; i <= end; i++) {
            int max = Math.Max(nums[i] + house2, house1);
            house2 = house1;
            house1 = max;
        }
        
        return house1;
    }
}
```
