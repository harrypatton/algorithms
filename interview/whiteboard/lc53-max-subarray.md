Source: https://leetcode.com/problems/maximum-subarray/#/description

Find the contiguous subarray within an array (containing at least one number) which has the largest sum.

For example, given the array [-2,1,-3,4,-1,2,1,-5,4],
the contiguous subarray [4,-1,2,1] has the largest sum = 6.

There're two solutions here. The first one is tricky on base values.

```csharp
public class Solution {
    public int MaxSubArray(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return 0;
        }
        
        int minSum = 0;
        int maxSum = int.MinValue;
        int currentSum = 0;
        
        for(int i = 0; i < nums.Length; i++) {
            currentSum += nums[i];
            maxSum = Math.Max(maxSum, currentSum - minSum);
            minSum = Math.Min(minSum, currentSum);
        }
        
        return maxSum;
        
//         int maxSum = nums[0];
//         int currentSum = nums[0];
        
//         for(int i = 1; i < nums.Length; i++) {
//             currentSum = currentSum >= 0 ? currentSum + nums[i] : nums[i];
//             maxSum = Math.Max(maxSum, currentSum);
//         }
        
//         return maxSum;
    }
}
```
