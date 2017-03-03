public class Solution {
    public bool Search(int[] nums, int target) {
        if (nums == null || nums.Length == 0) {
          return false;
        }
        
        int start = 0;
        int end = nums.Length - 1;
        
        while (start <= end) {
            var middle = start + (end - start) / 2;
            
            if (nums[middle] == target) {
                return true;
            }
            
            if (nums[middle] > nums[start]) {
                if (target >= nums[start] && target < nums[middle]) { // move to left
                    end = middle - 1;
                } else { // move to right
                    start = middle + 1;
                }
            } else if (nums[middle] < nums[start]) {
                if (target > nums[middle] && target <= nums[end]) { // move to right
                    start = middle + 1;
                } else { // move to left
                    end = middle - 1;
                }
            } else {
                if (nums[middle] != nums[end]) {
                    start = middle + 1;
                } else {
                    start++;
                    end--;
                }
            }
        }
        
        return false;
    }
}
