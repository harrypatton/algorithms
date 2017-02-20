public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) {
        var result = new List<IList<int>>();
        
        if (nums == null || nums.Length < 4) {
            return result;
        }
        
        Array.Sort(nums);
        
        for(int i = 0; i <= nums.Length - 4; i++) { // handle 4 sum
            // skip the same number (except the first one)
            if (i == 0 || nums[i] != nums[i-1]) {
                for (int j = i + 1; j <= nums.Length - 3; j++) { // handle 3 sum
                    if (j == i + 1 || nums[j] != nums[j-1]) { // skip the same number
                        int start = j + 1;
                        int end = nums.Length - 1;                        
                        
                        while(start < end) { // handle 2 sum
                            bool moveStart = false;
                            bool moveEnd = false;
                            
                            int sum = nums[i] + nums[j] + nums[start] + nums[end];
                            if (sum == target) {
                                result.Add(new List<int>(new int[] {nums[i], nums[j], nums[start], nums[end]}));
                                moveStart = true;
                                moveEnd = true;
                            } else if (sum  < target) {
                                moveStart = true;
                            } else {
                                moveEnd = true;
                            }
                            
                            if (moveStart) {                                
                                start++;
                                // skip dupe
                                while (start <= nums.Length - 2 && nums[start] == nums[start - 1]) { start++;}                                
                            }
                            
                            if (moveEnd) {
                                end--;
                                // skip dupe
                                while (end > start && nums[end] == nums[end + 1]) { end--;}
                            }
                        }
                    }
                }
            }
        }
        
        return result;
    }
}
