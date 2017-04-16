Source: https://leetcode.com/problems/find-right-interval/#/description

Given a set of intervals, for each of the interval i, 
check if there exists an interval j whose start point is bigger than or equal to the end point of the interval i, 
which can be called that j is on the "right" of i.

For any interval i, you need to store the minimum interval j's index, 
which means that the interval j has the minimum start point to build the "right" relationship for interval i. 
If the interval j doesn't exist, store -1 for the interval i. Finally, you need output the stored value of each interval as an array.

Note:

1. You may assume the interval's end point is always bigger than its start point.
2. You may assume none of these intervals have the same start point.

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

/*
1. sort the interval by start point
2. use a custom interval to record original position
3. use binary search to find the min right.
4. after finding the min right index, sort the back using original position.
5. output the result.

time: O(nlogn).
space: O(n)

without sorting, it is going to be O(n^2). BST helps to get O(nlogn).

Question: is there any way to keep original position without new class?
*/

public class NewInterval {
    public int start;
    public int position;
    public NewInterval(int s, int p) { 
        start = s; 
        position = p;
    }
}

public class Solution {
    public int[] FindRightInterval(Interval[] intervals) {
        if (intervals == null) return null;
        
        // save position information before sorting
        var newIntervals = new NewInterval[intervals.Length];
        for(int i = 0; i < intervals.Length; i++) {
            newIntervals[i] = new NewInterval(intervals[i].start, i);
        }
        
        // sort by start
        Array.Sort(newIntervals, (item1, item2) => item1.start - item2.start);
        
        // find min right
        var result = new int[intervals.Length];        
        for(int i = 0; i < intervals.Length; i++) {
            result[i] = FindMinRight(newIntervals, intervals[i].end);
        }
        
        return result;
    }
    
    public int FindMinRight(NewInterval[] intervals, int target) {
        int start = 0;
        int end = intervals.Length - 1;
        
        while(start <= end) {
            int middle = start + (end - start) / 2;
            
            if (intervals[middle].start == target) {
                return intervals[middle].position;
            } else if (intervals[middle].start > target) {
                end = middle - 1;
            } else {
                start = middle + 1;
            }
        }
        
        return start >= intervals.Length ? - 1 : intervals[start].position;
    }
}
```
