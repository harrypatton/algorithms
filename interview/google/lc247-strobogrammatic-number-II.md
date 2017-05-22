source: https://leetcode.com/problems/strobogrammatic-number-ii/#/description

A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).

Find all strobogrammatic numbers that are of length = n.

For example,
Given n = 2, return `["11","69","88","96"]`.

## Analysis
Easy to come up with the solution but be careful about the leading zero corner scenarios. Check code below how to handle that.

```c#
public class Solution {
    public IList<string> FindStrobogrammatic(int n) {
    	int count = n / 2;
        var result = new List<string>();
        if (n == 0) return result;

        if (n % 2 == 1) {
            result.Add("0");
            result.Add("1");
            result.Add("8");
        } else result.Add("");

        for(int i = 0; i < count; i++) {
            var tempResult = new List<string>();
            foreach(var str in result) {
                // don't generate leading zero.
                if (i != count - 1) tempResult.Add("0" + str + "0");
                
                tempResult.Add("1" + str + "1");
                tempResult.Add("8" + str + "8");
                tempResult.Add("6" + str + "9");
                tempResult.Add("9" + str + "6");
            }
            result = tempResult;
        }

        return result;
    }
}
```
