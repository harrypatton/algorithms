public class Solution_DP {
    public int LengthOfLIS(int[] nums) {
        if (nums == null || !nums.Any()) {
            return 0;
        }
        
        // init the base
        var cache = new int[nums.Length];
        cache[0] = 1;
        int max = 1;
        
        // starting from the 2nd element
        for(int i = 1; i < nums.Length; i++) {
            // find the max increasing length from previous elements
            var maxLength = 0;
            for(int j = 0; j < i; j++) {
                // check the length if previous element is less than current element
                if (nums[j] < nums[i] && cache[j] > maxLength) {
                    maxLength = cache[j];
                }
            }
            
            // including current element
            cache[i] = maxLength + 1;
            max = Math.Max(max, cache[i]);
        }
        
        return max;
    }
}
