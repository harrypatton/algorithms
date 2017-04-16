# LC56 - Merge Intervals
source: https://leetcode.com/problems/merge-intervals/#/description

Given a collection of intervals, merge all overlapping intervals.

For example,
```
Given [1,3],[2,6],[8,10],[15,18],
return [1,6],[8,10],[15,18].
```

It is very easy to write down the algorithm. Just need to be careful about the List.Sort(). The method exists in List class instead of IList interface, so I have to copy it to a list first. 

**code one time pass.**

```csharp
/**
 * Definition for an interval.
 * public class Interval {
 *     public int start;
 *     public int end;
 *     public Interval() { start = 0; end = 0; }
 *     public Interval(int s, int e) { start = s; end = e; }
 * }
 */
public class Solution {
    public IList<Interval> Merge(IList<Interval> intervals) {
        var result = new List<Interval>();
        
        if (intervals == null || intervals.Count == 0) {
            return result;
        }
        
        var tempIntervals = new List<Interval>(intervals);        
        tempIntervals.Sort((item1, item2) => item1.start - item2.start);
        intervals = tempIntervals;
        int start = intervals[0].start;
        int end = intervals[0].end;
        
        for(int i = 1; i < intervals.Count; i++) {
            if (end >= intervals[i].start) {
                end = Math.Max(end, intervals[i].end);
            } else {
                result.Add(new Interval(start, end));
                start = intervals[i].start;
                end = intervals[i].end;
            }
        }
        
        result.Add(new Interval(start, end));
        return result;
    }
}
```
