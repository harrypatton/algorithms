Source: https://leetcode.com/problems/wiggle-sort/#/description

## Problem
Given an unsorted array `nums`, reorder it in-place such that `nums[0] <= nums[1] >= nums[2] <= nums[3]....`

For example, given `nums = [3, 5, 2, 1, 6, 4]`, one possible answer is `[1, 6, 2, 5, 3, 4]`.

## Analysis
The editorial solution comes with much easier solution.

Good solution - sorting
1. sort the array first.
2. starting from the 2nd element, swap every pair.
  `1, 2, 3, 4, 5 => 1, 3, 2, 5, 4`

Good solution - swap with next

1. if position is odd, check current < next; if not, swap.
2. if position is even, check current > next; if not, swap.

why does it work?
* a1, a2, a3, a4 => assume a1 < a2. if a2 < a3, swap them so it is true that a1 < a3.
* a1, a2, a3, a4 => assume a1 < a2 > a3. if a3 > a4, swap them so it is true that a4 < a2.

My solution is too complicated and buggy. what I did,

1. sort the array and find the middle one.
2. insert every element in 2nd part into interval of the 1st part. It works fine but too complicated.

**Funny Thing**: I tried 30 minutes but failed to write the quick sort algorithm. Very funny.

```c#
public class Solution {    
    public void WiggleSort_Swap(int[] nums) {
        if (nums == null || nums.Length <= 1) return;

        // swap every pair.
        for(int i = 0; i < nums.Length - 1; i++) {
            if ((i % 2 == 0 && nums[i] > nums[i+1])
                || (i % 2 == 1 && nums[i] < nums[i+1])) {
                    var temp = nums[i];
                    nums[i] = nums[i + 1];
                    nums[i+1] = temp;
            }
        }
    }
    
    public void WiggleSort_Sort_SwapPair(int[] nums) {
        if (nums == null || nums.Length <= 1) return;

        Array.Sort(nums);

        // swap every pair.
        for(int i = 1; i < nums.Length - 1; i+=2) {
            var temp = nums[i];
            nums[i] = nums[i + 1];
            nums[i+1] = temp;
        }
    }
    
    public void WiggleSort(int[] nums) {
        if (nums == null || nums.Length <= 1) return;

        this.QuickSort(nums);

        // swap every pair.
        for(int i = 1; i < nums.Length - 1; i+=2) {
            var temp = nums[i];
            nums[i] = nums[i + 1];
            nums[i+1] = temp;
        }
    }
    
    public void QuickSort(int[] nums) {
        Sort(nums, 0, nums.Length - 1);
    }
    
    // quick sort implementation
    public void Sort(int[] nums, int i, int j) {
        if (i >= j) return;
        
        var start = i;
        var end = j;
        var pivot = nums[start + (end - start) / 2];
        
        while(start < end) {
            while(nums[start] < pivot) start++;
            while(nums[end] > pivot) end--;
            
            var temp = nums[start];
            nums[start] = nums[end];
            nums[end] = temp;
            start++;
            end--;
        }
        
        Sort(nums, i, start-1);
        Sort(nums, start + 1, j);
    }
}
```
