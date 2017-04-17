Source: https://leetcode.com/problems/next-greater-element-i/#/description

You are given two arrays (without duplicates) nums1 and nums2 where nums1’s elements are subset of nums2. Find all the next greater numbers for nums1's elements in the corresponding places of nums2.

The Next Greater Number of a number x in nums1 is the first greater number to its right in nums2. If it does not exist, output -1 for this number.

Example 1:
```
Input: nums1 = [4,1,2], nums2 = [1,3,4,2].
Output: [-1,3,-1]
Explanation:
    For number 4 in the first array, you cannot find the next greater number for it in the second array, so output -1.
    For number 1 in the first array, the next greater number for it in the second array is 3.
    For number 2 in the first array, there is no next greater number for it in the second array, so output -1.
```

Example 2:
```
Input: nums1 = [2,4], nums2 = [1,2,3,4].
Output: [3,-1]
Explanation:
    For number 2 in the first array, the next greater number for it in the second array is 3.
    For number 4 in the first array, there is no next greater number for it in the second array, so output -1.
```

Note:

1. All elements in nums1 and nums2 are unique.
2. The length of both nums1 and nums2 would not exceed 1000.

```c#
public class Solution {
    /*
    each array doesn't have duplicate elements.
    we can start with the second array to find the next greater number for every number.
    save the result in hash table so we can go back to first array to get result.
    remember, the first array is a subset of second one.
    
    use a stack and iterate each element.
    1. if stack is empty, push the element to stack.
    2. otherwise compare current element with stack peek.
    3. if less than peek, push to stack.
    4. if greater than peek, pop elements that are less than that element.
    5. when iteration is done, all elements in stack will have -1 (because of no next greater element.)
    We'll see all elements in stack are always in descending order.
    
    time complexity: O(m + n). space: O(n). n is the length of nums.
    */
    public int[] NextGreaterElement(int[] findNums, int[] nums) {
        if (findNums == null) return null;
        if (nums == null) return Enumerable.Repeat<int>(-1, findNums.Length).ToArray();
        
        var hash = new Dictionary<int, int>();
        var stack = new Stack<int>();
        
        for(int i = 0; i < nums.Length; i++) {
            while(stack.Count > 0 && stack.Peek() < nums[i]) {
                hash.Add(stack.Pop(), nums[i]);
            }
            stack.Push(nums[i]);
        }
        
        // in fact, we don't need this code block because not-found-key will default to -1.
        while(stack.Count > 0) {
          hash.Add(stack.Pop(), -1);
        }
        
        var result = new int[findNums.Length];
        for(int i = 0; i < findNums.Length; i++) {
            result[i] = hash.ContainsKey(findNums[i]) ? hash[findNums[i]] : -1;
        }
        
        return result;
    }
}
```
