public class Solution {
    public int MaxSubArray_DP(int[] nums) {
        int max = nums[0];
        int currentMax = nums[0];
        
        for(int i = 1; i < nums.Length; i++) {
            currentMax = Math.Max(currentMax + nums[i], nums[i]);
            max = Math.Max(max, currentMax);
        }
        
        return max;
    }
    
    public int MaxSubArray_AccumulativeSum(int[] nums) {
        int min = Math.Min(0, nums[0]);
        int max = nums[0];
        int sum = nums[0];
        
        for(int i = 1; i < nums.Length; i++) {
            sum += nums[i];
            max = Math.Max(max, sum - min);
            min = Math.Min(min, sum);
        }
        
        return max;
    }
}
