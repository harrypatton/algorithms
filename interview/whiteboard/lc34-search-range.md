source: https://leetcode.com/problems/search-for-a-range/#/description

Given an array of integers sorted in ascending order, find the starting and ending position of a given target value.

Your algorithm's runtime complexity must be in the order of O(log n).

If the target is not found in the array, return [-1, -1].

For example,
```
Given [5, 7, 7, 8, 8, 10] and target value 8,
return [3, 4].
```

```c#
/*
1. use binary search to find the result.
2. upper bound: when target is found, we should move start to middle + 1 so it never stops until reach next bigger element.
3. lower bound: try to find (target - 1) using the same algorithm.

edge cases:
1. after getting lower bound, check if the value equals target. If not, it means we don't find the element.
2. return results [lower_bound, upper_bound - 1]
*/
public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        if (nums == null) return null;
        
        var lower_bound = Find(nums, target - 1);
        
        if(lower_bound < nums.Length && nums[lower_bound] == target) {
            var upper_bound = Find(nums, target);
            return new int[] {lower_bound, upper_bound - 1};
        } else {
            return new int[] {-1, -1};
        }
    }
    
    public int Find(int[] nums, int target) {
        int start = 0;
        int end = nums.Length - 1;
        
        while(start <= end) {
            int middle = start + (end - start) / 2;
            
            if(nums[middle] <= target) start = middle + 1;
            else end = middle - 1;
        }
        
        return start;
    }
}
```
