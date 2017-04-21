https://leetcode.com/problems/house-robber/#/description

You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.

```csharp
/*
DP problem. 
1. use a variable to track max one.
2. f(n) means the max from [0..n] houses.
    f(n) = Max(f(n-1), nums[n] + f(n-2));
3. start with f(0) and f(1) to avoid edge cases.
*/
public class Solution {
    public int Rob(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return 0;
        } else if (nums.Length == 1) {
            return nums[0];
        }
        
        int house2 = nums[0];
        int house1 = Math.Max(house2, nums[1]);        
        
        for(int i = 2; i < nums.Length; i++) {
            int max = Math.Max(nums[i] + house2, house1);
            house2 = house1;
            house1 = max;
        }
        
        return house1;
    }
}
```
