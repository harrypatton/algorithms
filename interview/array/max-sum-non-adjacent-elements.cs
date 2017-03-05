    public class Solution {
        public int FindMaxSumOfNonAdjacentElements(int[] nums) {
            if (nums == null || nums.Length == 0) {
                return int.MinValue;
            }

            int result0 = nums[0];
            if (nums.Length == 1) {
                return result0;
            }

            int result1 = Math.Max(result0, nums[1]);
            if (nums.Length == 2) {
                return result1;
            }

            int result = 0;
            
            for(int i = 2; i < nums.Length; i++) {
                result = Math.Max(result0 + nums[i], result1);
                result0 = result1;
                result1 = result;
            }

            return result;
        }
    }
