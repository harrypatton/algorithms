public class Solution {
    public void MoveZeroes(int[] nums) {
        // edge cases.
        if (nums == null || nums.Length <= 1) {
            return;
        }
        
        int p = 0;
        
        for(int i = 0; i < nums.Length; i++) {
            if (nums[i] != 0) {
                if (p != i) {
                    nums[p] = nums[i];
                }
                p++;
            }
        }
        
        for(int i = p; i < nums.Length; i++) {
            nums[i] = 0;
        }
    }
}
