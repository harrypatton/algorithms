public class Solution {
    public bool PredictTheWinner(int[] nums) {
        // check parameters
        if (nums == null || !nums.Any()) {
          return false;
        }
        
        int length = nums.Length;
        int[,] result = new int[length + 1,length + 1];
        int sum = 0;
        
        // init the result
        for(int i = 0; i < length; i ++) {
            sum += nums[i];
            
            // one-element array
            result[i,i] = nums[i];
                        
            if (i < length - 1) {
                // 2-elements array
                result[i,i+1] = Math.Max(nums[i], nums[i+1]);
            }
        }
        
        // calculate the result
        for(int columnIndex = 2; columnIndex < length; columnIndex++) {
            int i = 0;
            int j = columnIndex;
            
            while (j < length) {
                int result1 = nums[i] + Math.Min(result[i+2,j], result[i+1,j-1]);
                int result2 = nums[j] + Math.Min(result[i+1,j-1], result[i,j-2]);
                result[i,j] = Math.Max(result1, result2);
                
                i++;
                j++;
            }
        }
        
        int play1 = result[0, length-1];
        int play2 = sum - play1;
        
        return play1 >= play2;
    }
}
