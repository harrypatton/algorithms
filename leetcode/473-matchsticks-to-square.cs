public class Solution {
    public bool Makesquare(int[] nums) {
        if (nums == null || nums.Length < 4) {
            return false;
        }
        
        int sum = 0;
        foreach(var num in nums) {
            if (num <= 0) {
                return false;
            }
            
            sum += num;
        }
        
        if (sum % 4 != 0) {
            return false;
        }
        
        var sumArray = new int[4];
        
        // sort the array by descending to speed (i.e., to fail it faster with bigger stick)
        Array.Sort(nums);
        Array.Reverse(nums);
        
        return makeSquareHelper(nums, 0, sumArray, sum /4);
    }
    
    public bool makeSquareHelper(int[] nums, int index, int[] sumArray, int target) {
        if (index == nums.Length) {
            return sumArray[0] == sumArray[1] && sumArray[0] == sumArray[2];
        }
        
        for(int i = 0; i < sumArray.Length; i++) {
            if (sumArray[i] + nums[index] > target) {
                continue;
            }
            
            sumArray[i] += nums[index];
            
            if (makeSquareHelper(nums, index + 1, sumArray, target)) {
                return true;
            } else {
                sumArray[i] -= nums[index];
            }
        }
        
        return false;
    }
}
