Source: https://leetcode.com/problems/move-zeroes/#/description

Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be [1, 3, 12, 0, 0].

Note:

1. You must do this in-place without making a copy of the array.
2. Minimize the total number of operations.
    
```c#
/*
move zeros and keep the order for non-zero numbers.
1. use two pointers
    a. iterate the array and use a pointer for non-zero number.
    b. in the end, fill in zero after the pointer.
*/
public class Solution {
    public void MoveZeroes(int[] nums) {
        if (nums == null) return;
        int index = 0;
        foreach(var num in nums) {
            if (num != 0) nums[index++] = num;
        }
        
        while(index < nums.Length) {
            nums[index++] = 0;
        }
    }
}
```
