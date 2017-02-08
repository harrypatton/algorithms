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
    
    private struct StartPosition {
        public int start;
        public int position;
        
        public StartPosition(int start, int position) {
            this.start = start;
            this.position = position;
        }
    }
    
    private class StartPositionComparer: IComparer<StartPosition> {
        public int Compare(StartPosition p1, StartPosition p2) {
            return p1.start - p2.start;
        }
    }
    
    public int[] FindRightInterval(Interval[] intervals) {
        if (intervals == null || !intervals.Any()) {
            return null;
        }

        // build up the start position array and sort it
        var positions = new StartPosition[intervals.Length];
        for(int i = 0; i < intervals.Length; i++) {
            positions[i] = new StartPosition(intervals[i].start, i);
        }
        
        Array.Sort<StartPosition>(positions, new StartPositionComparer());
        
        var result = new int[intervals.Length];
        for(int i = 0; i < intervals.Length; i++) {
            result[i] = FindRightIntervalIndex(intervals[i].end, positions);
        }
        
        return result;
    }
    
    private int FindRightIntervalIndex(int endPosition, StartPosition[] positions) {
        int low = 0;
        int high = positions.Length - 1;
        
        while(low <= high) {
            int middle = low + (high - low) / 2;
            
            if (positions[middle].start < endPosition) {
                low = middle + 1;
            } else if (positions[middle].start > endPosition) {
                high = middle - 1;
            } else { // the start of the right interval could be the same as end of current interval so be careful.
                low = middle;
                break;
            }
        }
        
        // if low reachs outside of boundary, we know there is no right edge so return -1.
        // in other cases, don't simply return the low. We need to choose the position value from that.
        return low == positions.Length ? -1 : positions[low].position;
    }
}
