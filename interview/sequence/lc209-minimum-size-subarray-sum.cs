public class Solution {
    public int MinSubArrayLen(int s, int[] nums) {
        if (s <= 0 || nums == null || nums.Length == 0) {
            return 0;
        }
        
        int start = 0;
        int end = 0;
        int sum = nums[0];
        int result = int.MaxValue;
        
        while (end < nums.Length) {            
            if (sum >= s) {
                result = Math.Min(result, end - start + 1);
                sum -= nums[start];
                start++;
                
                if (start < nums.Length && end < start) {
                    end = start;
                    sum = nums[start];
                }                
            } else {
                end++;
                if (end < nums.Length) {
                    sum += nums[end];
                }                
            }
        }
        
        return result == int.MaxValue ? 0 : result;
    }
}
