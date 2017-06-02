## Problem
source: https://leetcode.com/problems/kth-largest-element-in-an-array/#/description

Find the kth largest element in an unsorted array. Note that it is the kth largest element in the sorted order, not the kth distinct element.

For example,
`Given [3,2,1,5,6,4] and k = 2, return 5.`

Note: 
You may assume k is always valid, 1 ≤ k ≤ array's length.

## Analysis
A few solutions,

1. Sort and check
2. Use a min heap.
3. quick select - average is O(n), worse is O(n^2)

## Quick Select
See code below. I prefer the first quick select algorithm. The second one is ok but harder to understand. In either one, I just need to select a pivot value and swap it back when scan is done.

```c#
public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        int start = 0;
        int end = nums.Length - 1;
        
        while(start <= end) {
            var pivotVal = nums[end];
            int left = start;
            int right = end - 1;
            
            while(left <= right) {
                if(nums[left] > pivotVal) left++;
                else if(nums[right] <= pivotVal) right--;
                else Swap(nums, left++, right--);
            }
            
            Swap(nums, left, end);
            
            if(left + 1 == k) return pivotVal;
            else if (left + 1 < k) start = left + 1;
            else end = right;
        }
        
        return -1;
    }
    
    public int FindKthLargest_Textbook(int[] nums, int k) {
        int start = 0;
        int end = nums.Length - 1;
        
        while(start <= end) {
            var pivotVal = nums[start];
            Swap(nums, start, end);
            int p = start;
            for(int i = start; i < end; i++) {
                if(nums[i] > pivotVal) Swap(nums, i, p++);
            }
            
            Swap(nums, p, end);
            
            if (p + 1 == k) return nums[p];
            else if (p + 1 < k) start = p + 1;
            else end = p - 1;
        }
        
        return -1;
    }
    
    public void Swap(int[] nums, int i, int j) {
        var temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
```
