#473 - Matchsticks to Square
source: https://leetcode.com/problems/matchsticks-to-square/

**Problem**: given a list of sticks (which value is the length), verify if them can form a square. Each stick can link to another but cannot bend.

Examples
```
[1, 1, 1, 1, 3, 3, 3, 3] => [1+3, 1+3, 1+3, 1+3]
```

##Ideas
We can sum all of them and calculate the square size. The problem is to divide the array into four sub-arrays and the sum of each sub-array is equal to square size.

Another way to think of is, divide the array into 2 sub-arrays, each array has the same sum. In each each array, divide it again and each sub-array has the same sum. So the problem becomes a simple one - find an sub-array which value equals to (sum / 2). 

How to find an sub-array which sum is equal to ``sum/2``?
* f(n, sum) = f(n-1, sum) OR f(n-1, sum - element[n]).
* create 2d matrix: ``rows [0..sum]`` and ``columns [0..n-1]``. First row is all zero to start.

``Update``: I'm not sure if the above solution works. I look at the discussion on source link which uses the DFS solution. The idea becomes clear when check the code. Basically it tries every possible solution using recursion. The way used in recursion is pretty nice.

**Trick**: sort nums by descending order. In ``dfs``, the condition which determine whether ``dfs`` should keep exploring is this if ``side + nums[index] > length: continue``. When ``nums`` is sorted reversely, this condition will be hit sooner.

##Learning
1. DFS solution is a good way to solve NP-complete question. A trick is to end the exploring sooner.

```
public class Solution {
    public bool Makesquare(int[] nums) {
        if (nums == null || nums.Length < 4) {
            return false;
        }
        
        int sum = 0;
        foreach(var num in nums) {
            if (num <= 0) {
                return false;
            }
            
            sum += num;
        }
        
        if (sum % 4 != 0) {
            return false;
        }
        
        var sumArray = new int[4];
        
        // sort the array by descending to speed (i.e., to fail it faster with bigger stick)
        Array.Sort(nums);
        Array.Reverse(nums);
        
        return makeSquareHelper(nums, 0, sumArray, sum /4);
    }
    
    public bool makeSquareHelper(int[] nums, int index, int[] sumArray, int target) {
        if (index == nums.Length) {
            return sumArray[0] == sumArray[1] && sumArray[0] == sumArray[2];
        }
        
        for(int i = 0; i < sumArray.Length; i++) {
            if (sumArray[i] + nums[index] > target) {
                continue;
            }
            
            sumArray[i] += nums[index];
            
            if (makeSquareHelper(nums, index + 1, sumArray, target)) {
                return true;
            } else {
                sumArray[i] -= nums[index];
            }
        }
        
        return false;
    }
}
```
