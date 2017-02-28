public class Solution {
    public int MaxSubArray(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return 0;
        }
        
        int sum = 0;
        int result = int.MinValue;
        
        foreach(var num in nums) {
            sum = sum >= 0 ? sum + num : num;
            result = Math.Max(result, sum);
        }
        
        return result;
    }
}
