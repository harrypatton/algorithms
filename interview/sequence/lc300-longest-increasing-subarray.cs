public class Solution_NlogN {
    public int LengthOfLIS(int[] nums) {
        if (nums == null || !nums.Any()) {
            return 0;
        }
        
        // Array.BinarySearch needs an array.
        // to avoid memory allocation, I use int[] instead of List here.
        // be careful about the edge cases.
        // check the result from Array.BinarySearch (it is a little bit tricky)
        var result = new int[nums.Length];
        result[0] = nums[0];
        int resultLength = 1;
        
        for(int i = 1; i < nums.Length; i++) {
            // use binary search to update result list
            
            int pos = Array.BinarySearch<int>(result, 0, resultLength, nums[i]);
            
            // when pos >= 0, it finds the same element so we don't have do anything.
            if (pos < 0) {
                // choose the compliment use `~` operator.
                pos = ~pos;
                
                // update the result list.
                result[pos] = nums[i];
                
                // it means the result is bigger than all elements. so we add to the list.
                if (pos == resultLength) {
                    resultLength++;
                }
            }
        }
        
        return resultLength;
    }
}

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
