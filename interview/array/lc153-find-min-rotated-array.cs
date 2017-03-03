public class Solution {
    public int FindMin(int[] nums) {
        if (nums == null || nums.Length == 0) {
            throw new ArgumentException();
        }
        
        int start = 0;
        int end = nums.Length - 1;
        
        while (start < end) {
            var middle = start + (end - start) / 2;
            
            if (nums[middle] > nums[end]) {
                start = middle + 1;
            } else {
                end = middle;
            }
        }
        
        return nums[start];
    }
}
