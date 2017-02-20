public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        var result = new List<IList<int>>();
        if (nums == null) {
            return result;
        }
        
        // sort the array
        Array.Sort(nums);
        
        int i = 0;
        
        while (i < nums.Length - 2) {
            var subresult = TwoSum(nums, i+1, nums.Length - 1, -nums[i]);
            foreach(var list in subresult) {
                list.Insert(0, nums[i]);
            }
            
            result.AddRange(subresult);
            
            // move to a different number
            while (i < nums.Length - 2 && nums[i] == nums[++i]) {
            }
        }
        
        return result;
    }
    
    public IList<IList<int>> TwoSum(int[] nums, int start, int end, int target) {
        var result = new List<IList<int>>();
        
        while(start < end) {
            if (nums[start] + nums[end] < target) {
                start++;
            } else if (nums[start] + nums[end] > target) {
                end--;
            } else {
                var subResult = new List<int>();
                subResult.Add(nums[start]);
                subResult.Add(nums[end]);
                result.Add(subResult);
                
                // move to a different letter.
                start++;                                
                while (start < end && nums[start] == nums[start - 1]) {
                    start++;
                }
            }
        }
        
        return result;
    }
}
