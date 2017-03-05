    public class Solution {
        public int FindMaxSumOf2NonAdjacentElements(int[] nums) {
            if (nums == null || nums.Length < 3) {
                return int.MinValue;
            }

            int maxElement = nums[0];
            int previousElement = nums[1];
            int result = int.MinValue;

            for (int i = 2; i < nums.Length; i++) {
                result = Math.Max(result, nums[i] + maxElement);
                maxElement = Math.Max(maxElement, previousElement);
                previousElement = nums[i];
            }

            return result;
        }
    }
