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
        
        var intervalsArray = intervals.ToArray();
        Array.Sort(intervalsArray, (interval1, interval2) => interval1.start - interval2.start);
        
        Interval resultInterval = null;
        for(int i = 0; i < intervalsArray.Length; i++) {
            if (i == 0) {
                resultInterval = new Interval(intervalsArray[i].start, intervalsArray[i].end);
            } else if (intervalsArray[i].start <= resultInterval.end) {
                resultInterval.end = Math.Max(resultInterval.end, intervalsArray[i].end);
            } else {
                result.Add(resultInterval);
                resultInterval = new Interval(intervalsArray[i].start, intervalsArray[i].end);
            }
        }
        
        result.Add(resultInterval);
        return result;
    }
}
