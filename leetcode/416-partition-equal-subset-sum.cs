public class Solution {
    public bool CanPartition(int[] nums) {
        if (nums == null || !nums.Any()) {
            return false;
        }
        
        int totalSum = 0;
        foreach(var num in nums) {
            totalSum += num;
        }
        
        if (totalSum % 2 != 0) {
            return false;
        }
        
        int sum = totalSum / 2;        
        bool[] result = new bool[sum + 1];
        result[0]  = true;
        
        for(int i = 0; i < nums.Length; i++) {
            bool[] tempResult = new bool[sum + 1];
            
            for(int j = 0; j <= sum; j++) {
                tempResult[j] = result[j] || (j >= nums[i] && result[j - nums[i]]);
            }
            
            result = tempResult;
        }
        
        return result[sum];
    }
}
