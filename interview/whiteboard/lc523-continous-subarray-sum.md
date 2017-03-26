source: https://leetcode.com/problems/continuous-subarray-sum/#/solutions

This question has a lot of corner cases that it needs a Dictionary instead of HashSet to handle. I don't like this problem at all but just add here because of the interesting of `at least size 2` when handle sub-array question.

```csharp
public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        if (nums == null || nums.Length < 2) {
            return false;
        }        
        
        // handle negative situation
        if (k < 0) k = -k;
        
        if (k == 0) {
            for(int i = 1; i < nums.Length; i++) {
                if (nums[i] == 0 && nums[i] == nums[i-1]) return true;
            }
            
            return false;
        }
        
        var indexMapping = new Dictionary<int, int>();
        indexMapping[0] = -1;
        int sum = 0;
        for(int i = 0; i < nums.Length; i++) {
            sum += nums[i];
            int remainder = sum % k;
            
            if (indexMapping.ContainsKey(remainder)) {
                if (i > indexMapping[remainder] + 1) return true;
            } else {
                indexMapping[remainder] = i;
            }
        }
        
        return false;
    }
}
```
