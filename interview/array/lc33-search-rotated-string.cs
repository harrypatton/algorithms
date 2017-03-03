public class Solution {
    public int Search(int[] nums, int target) {
        if (nums == null || nums.Length == 0) {
          return -1;
        }
        
        int start = 0;
        int end = nums.Length - 1;
        
        while (start <= end) {
            var middle = start + (end - start) / 2;
            
            if (nums[middle] == target) {
                return middle;
            }
            
            if (nums[middle] >= nums[start]) {
                if (target >= nums[start] && target < nums[middle]) { // move to left
                    end = middle - 1;
                } else { // move to right
                    start = middle + 1;
                }
            } else {
                if (target > nums[middle] && target <= nums[end]) { // move to right
                    start = middle + 1;
                } else { // move to left
                    end = middle - 1;
                }
            }
        }
        
        return -1;
    }
}
