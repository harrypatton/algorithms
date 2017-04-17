source: https://leetcode.com/problems/next-greater-element-iii/#/description

Given a positive 32-bit integer n, you need to find the smallest 32-bit integer 
which has exactly the same digits existing in the integer n and is greater in value than n. 

If no such positive 32-bit integer exists, you need to return -1.

Example 1:
```
Input: 12
Output: 21
```

Example 2:
```
Input: 21
Output: -1
```

```c#
/*
use lexicographical order to do the work.
1. from backward, find the first element `first_small` which is smaller than next one.
2. from that position, backward again, find first element `first_greater` greater than it.
3. swap two positions
4. reverse the rest of array after `first_small` element

be careful about the edge case below,
test: 1,999,999,999 => 9,199,999,999 (too big)

that's why we need to try-catch there.
*/
public class Solution {
    public int NextGreaterElement(int n) {
        var str = n.ToString().ToCharArray();
        
        int start = str.Length - 2;
        while(start >= 0 && str[start] >= str[start + 1]) {
            start--;
        }
        
        if (start < 0) return -1;
        
        int end = str.Length - 1;
        while(end > start && str[end] <= str[start]) {
            end--;
        }
        
        Swap(str, start, end);
        
        int i = start + 1;
        int j = str.Length - 1;
        while(i < j) {
            Swap(str, i, j);
            i++; j--;
        }
        
        try {
            return Convert.ToInt32(new string(str));
        } catch(OverflowException) {
            return -1;
        }
        
    }
    
    public void Swap(char[] str, int i, int j) {
        var temp = str[i];
        str[i] = str[j];
        str[j] = temp;
    }
}
```
