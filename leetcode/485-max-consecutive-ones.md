#Max Consecutive Ones

##Question
Given a binary array, find the maximum number of consecutive 1s in this array.

Example 1:
```
Input: [1,1,0,1,1,1]
Output: 3
Explanation: 
  The first two digits or the last three digits are consecutive 1s. 
  The maximum number of consecutive 1s is 3.
```

##Solution - 1
```
public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        int maxCount = 0;
        int currentCount = 0;
        
        foreach(var num in nums) {
            if (num == 0) { // run into a zero
                maxCount = Math.Max(currentCount, maxCount);
                currentCount = 0; // reset
            } else {
                currentCount++;
            }
        }
        
        maxCount = Math.Max(currentCount, maxCount);        
        return maxCount;
    }
}
```

##Solution - 2
```
public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        int maxCount = 0;
        int currentCount = 0;
        
        foreach(var num in nums) {            
            currentCount = num == 0 ? 0 : currentCount+1;
            maxCount = Math.Max(maxCount, currentCount);
        }
        
        return maxCount;
    }
}
```

##Learning
1. the question is very easy but solution is simpler without duplicate code like ``Math.Max``. The idea is use currentCount for the consecutive ones ending with current element. If ``Math.Max`` is very expensive, we can use solution #1.
