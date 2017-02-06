public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        var result = new List<int>();
        
        if (nums == null || !nums.Any()) {
            return result;
        }
        
        foreach (var num in nums) {
            var tempNum = Math.Abs(num);
            var index = tempNum - 1;
            
            if (nums[index] < 0) {
                result.Add(tempNum);
            } else {
                nums[index] = 0 - nums[index];
            }
        }
        
        return result;
    }
}
