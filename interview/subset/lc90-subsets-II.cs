public class Solution_backtracking {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        var result = new List<IList<int>>();
        
        if (nums == null) {
            return result;
        }
        
        Array.Sort(nums);
        Backtracking(nums, 0, new List<int>(), result);
        return result;
    }
    
    public void Backtracking(int[] nums, int start, IList<int> list, IList<IList<int>> result) {        
        result.Add(new List<int>(list));
        
        while (start < nums.Length) {            
            // calculate how many duplicate characters we're handling
            int count = 1;
            int i = start;
            while(i < nums.Length - 1 && nums[i] == nums[i+1]) {
                count++;
                i++;
            }
            
            int newStart = start + count;
            
            for(int j=0; j < count;j++) {
                list.Add(nums[start]);
                Backtracking(nums, newStart, list, result);
            }
            
            for(int j=0; j < count;j++) {
                list.Remove(nums[start]);
            }
            
            start = newStart;
        }
    }
}
