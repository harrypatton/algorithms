* Source: https://leetcode.com/problems/non-overlapping-intervals/#/solutions
* Article: https://leetcode.com/articles/non-overlapping-intervals/

Given a collection of intervals, find the minimum number of intervals you need to remove to make the rest of the intervals non-overlapping.

Note:

1. You may assume the interval's end point is always bigger than its start point.
2. Intervals like [1,2] and [2,3] have borders "touching" but they don't overlap each other.

```csharp
public class Solution {
    public int EraseOverlapIntervals(Interval[] intervals) {
        if(intervals == null || intervals.Length <= 1) return 0;
        
        Array.Sort(intervals, (item1, item2) => item1.end - item2.end);
        int count = 1;
        int end = intervals[0].end;
        
        for(int i = 1; i < intervals.Length; i++) {
            if (intervals[i].start >= end) {
                count++;
                end = intervals[i].end;
            }
        }
        
        return intervals.Length - count;
    }
}
```
