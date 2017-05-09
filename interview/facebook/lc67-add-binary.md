source:https://leetcode.com/problems/add-binary/#/description

Given two binary strings, return their sum (also a binary string).

## Analysis
This is an easy problem to solve but I still made a few mistakes while coding after lunch time. Bad productivity :(.

```c#
/*
Solution: Maintain two pointers and a flag to indicate overflow or not.
string builder - use insert.
*/
public class Solution {
    public string AddBinary(string a, string b) {
        // a="0", b="0"
        if (a == null || b == null || a.Length == 0 || b.Length == 0) return null;
        int flag = 0;
        int index1 = a.Length - 1;
        int index2 = b.Length - 1;
        var result = new StringBuilder();
        while(index1 >= 0 || index2 >= 0) {
            var value = flag + (index1 >= 0 ? a[index1] - '0' : 0) + (index2 >= 0 ? b[index2] - '0' : 0);
            flag = value >= 2 ? 1 : 0;
            result.Insert(0, value % 2 == 0 ? '0' : '1');
            index1--;
            index2--;
        }
        
        if (flag == 1) result.Insert(0, '1');
        return result.ToString();
    }
}
```
