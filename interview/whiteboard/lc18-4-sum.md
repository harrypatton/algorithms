[Source](https://leetcode.com/problems/4sum/#/description)

It is a typical problem to solve. When I wrote the code, I forgot to remove dupe and then went back to add it. It is easiser to do that.
It took me a little time to remove dupe in `Get2Sum method`. 

Basically I want to move next different element but don't go outside. I have to write two lines here.

```csharp
public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) {
        var result = new List<IList<int>>();        
        if (nums == null || nums.Length < 4) return result;
        
        Array.Sort(nums);
        
        for(int i = 0; i < nums.Length - 3; i++) {
            if (i > 0 && nums[i] == nums[i-1]) continue;            
            var subResult = Get3Sum(nums, i + 1, target - nums[i]);
            foreach(var list in subResult) {
                list.Add(nums[i]);
                result.Add(list);
            }
        }
        
        return result;
    }
    
    public IList<IList<int>> Get3Sum(int[] nums, int start, int target) {
        var result = new List<IList<int>>();        
        if (nums.Length - start < 3) return result;
        
        for(int i = start; i < nums.Length - 2; i++) {
            if (i > start && nums[i] == nums[i-1]) continue;
            var subResult = Get2Sum(nums, i + 1, target - nums[i]);
            foreach(var list in subResult) {
                list.Add(nums[i]);
                result.Add(list);
            }
        }
        
        return result;
    }
    
    public IList<IList<int>> Get2Sum(int[] nums, int start, int target) {
        var result = new List<IList<int>>();        
        if (nums.Length - start < 2) return result;
        int end = nums.Length - 1;
        
        while(start < end) {
            if(nums[start] + nums[end] == target) {
                result.Add(new List<int>(new int[] {nums[start], nums[end]}));                
                start++;
                while(start < nums.Length && nums[start] == nums[start - 1]) start++;
            } else if(nums[start] + nums[end] < target) {
                start++;
            } else {
                end--;
            }
        }
        
        return result;
    }
}
```
