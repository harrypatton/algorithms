## Problem
Source: https://leetcode.com/problems/insert-interval/#/description

Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).

You may assume that the intervals were initially sorted according to their start times.

```
Given intervals [1,3],[6,9], insert and merge [2,5] in as [1,5],[6,9].
Given [1,2],[3,5],[6,7],[8,10],[12,16], insert and merge [4,9] in as [1,2],[3,10],[12,16].
This is because the new interval [4,9] overlaps with [3,5],[6,7],[8,10].
```

## Analysis
This is a question asked by Uber. It should be easy but I wasn't in good state so I failed it.
intervals is a group of non-overlapping and start-time based sorted intervals.

It is intuitive to think of Binary Search solution; however, the edge cases are a little bit tricky to handle.
See the code below. Although this solution is still O(n), but assume we use LinkedList, it could be O(logn).

1. use BS to find the first element start >= newInterval.start.
2. use BS to find the first element start >= newInterval.end.
3. add all elements before the element from #1.
4. merge elements between #1 and #2. Be careful about the edge cases. 
5. add the rest.

A clean solution is just to scan every element and merge if possibile.
 
## Code - binary search
```c#
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
    public IList<Interval> Insert_BS(IList<Interval> intervals, Interval newInterval) {
        if (intervals == null) return null;

        var result = new List<Interval>();
        var left = BinarySearch(intervals, newInterval.start);
        var right = BinarySearch(intervals, newInterval.end);

        // handle edge cases when new interval overlaps with the (left - 1) element.
        if (left > 0 && intervals[left - 1].end >= newInterval.start) left--;

        // handle edge cases when no overlap interval.
        if (right == intervals.Count || (intervals[right].start > newInterval.end)) {
            right--;
        }

        for(int i = 0; i <= left - 1; i++) result.Add(intervals[i]);

        int start = (left >= 0 && left < intervals.Count) 
            ? Math.Min(intervals[left].start, newInterval.start) : newInterval.start;

        int end = (right >= 0 && right < intervals.Count) 
            ? Math.Max(intervals[right].end, newInterval.end) : newInterval.end;

        result.Add(new Interval(start, end));

        for(int i = right + 1; i < intervals.Count; i++) result.Add(intervals[i]);

        return result;
    }

    public int BinarySearch(IList<Interval> intervals, int target) {
        int start = 0;
        int end = intervals.Count - 1;
        while(start <= end) {
            int middle = start + (end - start) / 2;
            if (intervals[middle].start == target) break;
            else if (intervals[middle].start > target) end = middle - 1;
            else start = middle + 1;
        }

        return start;
    }
}
```

```c#

## O(n) Iteration
public class Solution {
    public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval) {
        if (intervals == null) return null;

        var result = new List<Interval>();
        int index = 0;
        while(index < intervals.Count && intervals[index].end < newInterval.start) {
            result.Add(intervals[index++]);
        }

        while(index < intervals.Count && intervals[index].start <= newInterval.end) {
            newInterval.start = Math.Min(newInterval.start, intervals[index].start);
            newInterval.end = Math.Max(newInterval.end, intervals[index].end);
            index++;
        }

        result.Add(newInterval);

        while(index < intervals.Count) {
            result.Add(intervals[index++]);
        }        

        return result;
    }
}
```
