public class Solution_Recursion {
    public int CombinationSum4(int[] nums, int target) {
        if (nums == null || target < 0) {
            return 0;
        } else if (target == 0) {
            return 1;
        }
        
        int result = 0;
        foreach(var num in nums) {
            result += CombinationSum4(nums, target - num);
        }
        
        return result;
    }
}

public class Solution_DP {
    public int CombinationSum4(int[] nums, int target) {
        if (nums == null || target < 0) {
            return 0;
        }
        
        var result = new int[target + 1];
        result[0] = 1;
        
        for(int i = 1; i <= target; i++) {
            foreach(var num in nums) {
                if (i >= num) {
                    result[i] += result[i - num];
                }                
            }
        }
        
        return result[target];
    }
}
