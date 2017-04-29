Discussion page has a better solution with clean code.

```c#
/*
increasing sequence with 3 elements.

Solutions: 
1. DP: maintain a min value, f(n) is true if there's an 2-element increasing elements using that value.
maintain a f(m) which value is true element m is the smallest.
    a. basically we need to check if previous sub array has increasing sequence.
    b. when yes, we need to keep the one with min bigger value so latter element has bigger chance.

The DP doesn't work because it cannot handle the situation when current value is very small. 
After replacing the min value, what about the min_Max?

example: [1,2,-10,-8,-7]

1, 3, 2, 4

*/
public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        if (nums == null || nums.Length < 3) return false;
        
        int minValue = nums[0];
        int? value1 = null;
        int? value2 = null;
        
        for(int i = 1; i < nums.Length; i++) {
            if (value1 != null && value2 != null && nums[i] > value2) {
                return true;
            } else if (value1 == null) {
                if (nums[i] > minValue) {
                    value1 = minValue;
                    value2 = nums[i];
                } else minValue = nums[i];
            } else if (nums[i] > minValue) {
                value1 = minValue;
                value2 = nums[i];
            } else minValue = nums[i];
        }
        
        return false;
    }
    
    public bool IncreasingTriplet_BadCode(int[] nums) {
        if (nums == null || nums.Length < 3) return false;
        
        int minValue = nums[0];
        int? min_Max = null;
        
        for(int i = 1; i < nums.Length; i++) {
            if (nums[i] > minValue) {
                if (min_Max != null && nums[i] > min_Max) {
                    return true;
                } else {
                    min_Max = nums[i];
                }
            } else {
                minValue = nums[i];
            }
        }
        
        return false;
    }
}
```
