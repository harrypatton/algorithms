public class Solution {
    public string LargestNumber(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return string.Empty;
        }
        
        Array.Sort<int>(nums, (num1, num2) => Compare(num1, num2));
        
        if (nums[nums.Length - 1] == 0) {
            return "0";
        }
        
        var result = new StringBuilder();
        
        for(int i = nums.Length - 1; i >= 0; i--) {
            result.Append(nums[i].ToString());
        }
        
        return result.ToString();
    }
    
    public int Compare(int num1, int num2) {
        var numStr1 = num1.ToString();
        var numStr2 = num2.ToString();
        
        return string.Compare(numStr1 + numStr2, numStr2 + numStr1);
    }
}
