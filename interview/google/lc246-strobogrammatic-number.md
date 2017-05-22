source: https://leetcode.com/problems/strobogrammatic-number/#/description

A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).

Write a function to determine if a number is strobogrammatic. The number is represented as a string.

For example, the numbers "69", "88", and "818" are all strobogrammatic.

## Analysis
It is easy to come up with the solution, given that a few digits can be strobogrammatic.

```c#
public class Solution {
    public bool IsStrobogrammatic(string num) {
        if (num == null || num.Length == 0) return false;

        var s = new StringBuilder();
        foreach(var c in num) {
        	var newChar = '0';
        	if (c == '0' || c == '1' || c == '8') newChar = c;
        	else if (c == '6') newChar = '9';
        	else if (c == '9') newChar = '6';
        	else return false;

        	s.Append(newChar);
        }

        // compare the result - should be reversed.
        for(int i = 0; i < num.Length; i++) {
        	if (num[i] != s[num.Length - 1 - i]) return false;
        }

        return true;
    }
}
```
