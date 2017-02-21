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

public class Solution_Iteration {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        var result = new List<IList<int>>();
        
        if (nums == null) {
            return result;
        }
        
        Array.Sort(nums);
        
        int index = 0;
        result.Add(new List<int>());
        
        while(index < nums.Length) {
            int count = 1;
            
            // find current repetitive numbers
            while (index < nums.Length - 1 && nums[index] == nums[index+1]) {
                count++;
                index++;
            }
            
            var list = new List<int>();
            int length = result.Count;
            
            for(int i = 0; i < count; i++) {
                list.Add(nums[index]);
                                
                for(int j = 0; j < length; j++) {
                    var tempList = new List<int>(list);
                    tempList.AddRange(result[j]);
                    result.Add(tempList);
                }
            }
            
            // when the inner while quit, the index is either at the end of repetitive char
            // or reach the last element. we need to increase it for next loop.
            index++;
        }
        
        return result;
    }
}
