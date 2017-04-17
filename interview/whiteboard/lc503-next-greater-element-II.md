source: https://leetcode.com/problems/next-greater-element-ii/#/description

Given a circular array (the next element of the last element is the first element of the array), 
print the Next Greater Number for every element. 

The Next Greater Number of a number x is the first greater number to its traversing-order next in the array, 
which means you could search circularly to find its next greater number. 

If it doesn't exist, output -1 for this number.

Example 1:
```
Input: [1,2,1]
Output: [2,-1,2]
Explanation: The first 1's next greater number is 2; 
The number 2 can't find next greater number; 
The second 1's next greater number needs to search circularly, which is also 2.
```

Note: The length of given array won't exceed 10000.

```c#
public class Solution {
    /*
    the array may contains duplicate elements.
    it is a circular array so all elements except the max one should have values.
    
    naive solution is to iterate every element and find its biggest one. n * n = O(n^2).
    
    like the previous problem `next greater element`, we can use array to store elements in descending order.
    The problem is how to store the position information (the array may have dupe so hash table doesn't work).
    
    one way is to introduce another data structure including both position and value. e.g., key value pair.
    
    use a stack and iterate each element.
    1. if stack is empty, push the element to stack.
    2. otherwise compare current element with stack peek.
    3. if less than peek, push to stack.
    4. if greater than peek, pop elements that are less than that element.
    5. when iteration is done, go through the array again; however, this time we don't push element.
    We'll see all elements in stack are always in descending order.
    
    time complexity: O(n). space: O(n).
    
    update: actually we can use stack to store index though.
    */
    public int[] NextGreaterElements(int[] nums) {
        if (nums == null) return null;
        var result = Enumerable.Repeat<int>(-1, nums.Length).ToArray();        
        var stack = new Stack<int>();
        
        for(int i = 0; i < nums.Length * 2; i++) {
            int index = i % nums.Length;
            while(stack.Count > 0 && nums[stack.Peek()] < nums[index]) {
                result[stack.Pop()] = nums[index];
            }
            
            if (i < nums.Length) stack.Push(i);
        }
        
        return result;
    }

    
    public int[] NextGreaterElements_old(int[] nums) {
        if (nums == null) return null;
        var result = Enumerable.Repeat<int>(-1, nums.Length).ToArray();        
        var stack = new Stack<KeyValuePair<int, int>>();
        
        for(int i = 0; i < nums.Length * 2; i++) {
            int index = i % nums.Length;
            while(stack.Count > 0 && stack.Peek().Value < nums[index]) {
                result[stack.Pop().Key] = nums[index];
            }
            
            if (i < nums.Length) stack.Push(new KeyValuePair<int, int>(i, nums[i]));
        }
        
        return result;
    }
}
```
