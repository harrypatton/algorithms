Source: https://leetcode.com/problems/two-sum/#/description

Given an array of integers, return indices of the two numbers such that they add up to a specific target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

Example:
```
Given nums = [2, 7, 11, 15], target = 9,
Because nums[0] + nums[1] = 2 + 7 = 9,
return [0, 1].
```

```c#
/*
Solution 1: 
the naive way is to iterate every element. during the loop, iterate the rest of elements in the array and check if the sum is the same as target value.
time: O(n^2), space O(1)

Solution 2: sort the array (of course we have to introduce another data structure to store index information). two pointers to get the sum. 
time: O(nlogn), space O(n). sorting is expensive.

Solution 3: use hash table
Iterate the element, if (sum - current_element) is in hash table, we found the result; otherwise add it with (value, index).
tiem: O(n), space: O(n)
duplicate elements? because the problem shows only one exactly solution, so it is ok to overwrite/ignore it.
*/
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        if(nums == null || nums.Length < 2) return null;
        
        var dict = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++) {
            if(dict.ContainsKey(target - nums[i])) {
                return new int[] {dict[target - nums[i]], i};
            } else {
                dict[nums[i]] = i;
            }
        }
        
        return null;
    }
}
```
