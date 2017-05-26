Source: https://leetcode.com/problems/3sum-smaller/#/description

Given an array of n integers nums and a target, find the number of index triplets `i, j, k` with `0 <= i < j < k < n` 
that satisfy the condition `nums[i] + nums[j] + nums[k] < target`.

For example, given `nums = [-2, 0, 1, 3]`, and `target = 2`.

Return 2. Because there are two triplets which sums are less than 2:
```
[-2, 0, 1]
[-2, 0, 3]
```

## Analysis
1. naive solution is n^3. pick up one element and check if two elements in the rest of array is less than target - element.
2. if we sort the array, and then use two pointers, it would be nlogn + n^2 so total is O(n^2).
    actually I'm not sure how to use two pointers. when start + end < target, what's next?
    I can use a dictionary to store 2 pair sum; however, not sure if the sum includes element we are testing.
3. Go back two pointers again. I think I can figure it out.
    * if a[i] + a[j] < target, count could be j - i, i.e., (i, i + 1), (i, i +2), ... (i, j).
        after that, i++ and test again.
    * if a[i] + a[j] >= target, j--; there's no other choice. 
    * when i == j, stop.
4. I cannot figure out a DP solution. Does it even exist?
5. Although two pointer solution is the best, discussion page also shows binary search (which is a little worse), but it is good to know other solutions.

## Two Pointers
``` C#
public class Solution {
    public int ThreeSumSmaller(int[] nums, int target) {
        int count = 0;
        if (nums == null || nums.Length < 3) return count;

        Array.Sort(nums);

        for(int i = 0; i <= nums.Length - 3; i++) {
            int start = i + 1;
            int end = nums.Length - 1;
            int newTarget = target - nums[i];

            while(start < end) {
                if (nums[start] + nums[end] < newTarget) {
                    count += end - start;
                    start++;
                } else end--;
            }
        }

        return count;
    }
}
```
