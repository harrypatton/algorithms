public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        if (nums == null || nums.Length < 3) {
            return 0;
        }
        
        Array.Sort(nums);        
        int result = nums[0] + nums[1] + nums[2];
        
        for(int i = 0; i < nums.Length - 2; i++) {
            int subResult = nums[i] + TwoSum(nums, i + 1, nums.Length - 1, target - nums[i]);
            if (Math.Abs(result - target) > Math.Abs(subResult - target)) {
                result = subResult;
            }
        }
        
        return result;
    }
    
    public int TwoSum(int[] nums, int start, int end, int target) {
        int result = nums[start] + nums[end];
        
        while(start < end) {
            int currentSum = nums[start] + nums[end];
            
            if (Math.Abs(result - target) > Math.Abs(currentSum - target)) {
                result = currentSum;
            }
            
            if (currentSum < target) {                
                start++;
            } else if (currentSum > target) {
                end--;
            } else {
                break;
            }
        }
        
        return result;
    }
}
