Source: https://leetcode.com/problems/missing-ranges/#/description

Given a sorted integer array where `the range of elements are in the inclusive range [lower, upper]`, return its missing ranges.

For example, `given [0, 1, 3, 50, 75], lower = 0 and upper = 99`, return `["2", "4->49", "51->74", "76->99"]`.

## Analysis
Be careful about overflow scenario that's why I use `long` type for lower/upper and the array element.

```c#
public class Solution {
    public IList<string> FindMissingRanges(int[] nums, int lower, int upper) {
        var result = new List<string>();
        if (nums == null) return result;
        long longLower = lower;
        long longUpper = upper;

        foreach(long n in nums) {
        	if (longLower > longUpper) break;
        	if (n >= longLower && n <= longUpper) {
        		if (n > longLower) {
        			if (longLower == n - 1) result.Add(longLower.ToString());
        			else result.Add(string.Format("{0}->{1}", longLower, n - 1));
        		}

        		longLower = n + 1;
        	}
        }

        if (longLower < longUpper) result.Add(string.Format("{0}->{1}", longLower, longUpper));
        else if (longLower == longUpper) result.Add(longLower.ToString());

        return result;
    }
}
```
