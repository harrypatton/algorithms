public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        if (nums == null) {
            return null;
        }
        
        var map = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++) {
            int otherNum = target - nums[i];
            
            if (map.ContainsKey(otherNum)) {
                return new int[] {map[otherNum], i};
            } else {
                map[nums[i]] = i;
            }
        }
        
        return null;
    }
}
