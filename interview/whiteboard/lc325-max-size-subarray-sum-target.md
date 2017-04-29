Source: https://discuss.leetcode.com/topic/33259/o-n-super-clean-9-line-java-solution-with-hashmap

Given an array nums and a target value k, find the maximum length of a subarray that sums to k. If there isn't one, return 0 instead.

Example 1:
```
Given nums = [1, -1, 5, -2, 3], k = 3,
return 4. (because the subarray [1, -1, 5, -2] sums to 3 and is the longest)
```

Example 2:
```
Given nums = [-2, -1, 2, 1], k = 1,
return 2. (because the subarray [-1, 2] sums to 1 and is the longest)
```

Follow Up:
`Can you do it in O(n) time?`

## Note
1. My solution updates the original array and scan twice. 
Actually we can scan and compare at the same time so we don't need to update orignal array.
what we really need is current sum and the hash table.
2. Other than adding a [0, -1] pair in hash table, we can also use `if (sum == target) max = i + 1;` it is more readable.


```c#
/*
Solution - hash table.
1. update the array so that each element is the sum of subarray starting from 0 to current position.
2. iterate over the new array and use a hash table.
    a. if hash table contains (target - element[i]), result = Math.Max(result, i - hash[target-element[i]])
    b. if hash table doesn't contain element[i], add it with value i. 
    c. otherwise; do nothing. (we want to keep the min position value)
3. need to handle edge case for single element. what if hash table hardcoded like hash[0] = -1.

*/
public class Solution {
    public int GetMaxSubarrayWithSumK(int[] nums, int target) {
        if (nums == null || nums.Length == 0) return -1;
        var sum = 0;
        
        for(int i = 0; i < nums.Length; i++) {
            sum += nums[i];
            nums[i] = sum;
        }
        
        var dict = new Dictionary<int, int>();
        dict[0] = -1;
        
        int max = -1;
        for(int i = 0; i < nums.Length; i++) {
            var diff = target - nums[i];
            
            if (dict.ContainsKey(diff)) {
                max = Math.Max(max, i - dict[diff]);
            }
            
            if (!dict.ContainsKey(nums[i])) {
                dict[nums[i]] = i;
            }
        }
        
        return max;
    }
}
```
