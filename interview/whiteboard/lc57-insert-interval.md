Source: https://leetcode.com/problems/insert-interval/#/description

Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).
You may assume that the intervals were initially sorted according to their start times.

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

// we assume intervals are already sorted.
// we need to insert the newInterval and merge if any overlap.
// we could check one by one or use binary search to quickly get start and end.
// it could be the front of end of the list.
public class Solution {

        /*
    iterate each element and check merge or not. 
    */
    public IList<Interval> Insert_Iterate(IList<Interval> intervals, Interval newInterval) {
        var result = new List<Interval>();
        if (intervals == null) return result;
        
        int index = 0;
        
        // handle left part which doesn't merge with new interval
        while(index < intervals.Count && intervals[index].end < newInterval.start) {
            result.Add(intervals[index]);
            index++;
        }
        
        // handle merge part
        while(index < intervals.Count && intervals[index].start <= newInterval.end) {
            newInterval.start = Math.Min(newInterval.start, intervals[index].start);
            newInterval.end = Math.Max(newInterval.end, intervals[index].end);            
            index++;
        }
        
        result.Add(newInterval);
        
        // handle right part which doesn't merge with new interval
        while(index < intervals.Count) {
            result.Add(intervals[index]);
            index++;
        }
        
        return result;
    }    
    
    /*
    find the last element in left part that doesn't merge; (could use binary search)
    find the first element in right part that doesn't merge; (could use binary serach)
    copy and handle the merge.
    */
    public IList<Interval> Insert_left_right_first(IList<Interval> intervals, Interval newInterval) {
        var result = new List<Interval>();
        if (intervals == null) return result;
        
        int index = 0;
        
        // find last element in left part which doesn't merge with new interval
        while(index < intervals.Count && intervals[index].end < newInterval.start) {
            index++;
        }
        
        int left = index - 1;
        
        // find first element in right part which doesn't merge with new interval
        while(index < intervals.Count) {
            if (intervals[index].start > newInterval.end) {
                break;
            }
            index++;
        }
        
        int right = index;
        
        // handle left
        for(int i = 0; i <= left; i++) {
            result.Add(intervals[i]);
        }
        
        // handle merge part
        for(int i = left + 1; i < right; i++) {
            newInterval.start = Math.Min(newInterval.start, intervals[i].start);
            newInterval.end = Math.Max(newInterval.end, intervals[i].end);            
        }       
        
        result.Add(newInterval);
        
        // handle right
        for(int i = right; i < intervals.Count; i++) {
            result.Add(intervals[i]);
        }
                       
        return result;
    }   
    
    /*
    find the last element in left part that doesn't merge; (could use binary search)
    find the first element in right part that doesn't merge; (could use binary serach)
    copy and handle the merge.
    */
    public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval) {
        var result = new List<Interval>();
        if (intervals == null) return result;
        
        int start = 0;
        int end = intervals.Count - 1;
        
        while(start <= end) {
            int middle = start + (end - start) / 2;
            if (intervals[middle].end <= newInterval.start) {
                start = middle + 1;
            } else {
                end = middle - 1;
            }
        }
        
        // this part is very tricky
        // we know start is next bigger one.
        // minus 1 may still be equal to the end 
        // so we still need one offset.
        int left = start - 1;
        if (left >= 0 && intervals[left].end == newInterval.start) {
            left--;
        }
        
        start = 0;
        end = intervals.Count - 1;
        
        while(start <= end) {
            int middle = start + (end - start) / 2;
            if (intervals[middle].start <= newInterval.end) {
                start = middle + 1;
            } else {
                end = middle - 1;
            }
        }
        
        int right = start;
        
        // handle left
        for(int i = 0; i <= left; i++) {
            result.Add(intervals[i]);
        }
        
        // handle merge part
        for(int i = left + 1; i < right; i++) {
            newInterval.start = Math.Min(newInterval.start, intervals[i].start);
            newInterval.end = Math.Max(newInterval.end, intervals[i].end);            
        }       
        
        result.Add(newInterval);
        
        // handle right
        for(int i = right; i < intervals.Count; i++) {
            result.Add(intervals[i]);
        }
                       
        return result;
    }    
}
```
