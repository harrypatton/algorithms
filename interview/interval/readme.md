#Meeting Room Scheduling Problem
**Source**

* http://blog.gainlo.co/index.php/2016/07/12/meeting-room-scheduling-problem/
* They are also LC252 and LC253 (which are locked by subscription for now but we can check answers).
	* lc252: https://discuss.leetcode.com/category/316/meeting-rooms
	* lc253: https://discuss.leetcode.com/category/317/meeting-rooms-ii

*Given a list of meeting times, checks if any of them overlaps. The follow-up question is to return the minimum number of rooms required to accommodate all the meetings.*

Let’s start with an example. Suppose we use interval (start, end) to denote the start and end time of the meeting, we have the following meeting times: (1, 4), (5, 6), (8, 9), (2, 6). In the above example, apparently we should return true for the first question since (1, 4) and (2, 6) have overlaps. For the follow-up question, we need at least 2 meeting rooms so that (1, 4), (5, 6) will be put in one room and (2, 6), (8, 9) will be in the other.

## Analysis
1. Overlap - first thing coming in my mind is sorting.
	* say sorting by start element.
	* if `previous.End > current.Start`, there's an overlap.
	* Edge cases
		* when two pairs have the same start. It doesn't matter which one comes first in this case because it detects the overlap in any order.
	* time complexity: O(nlogn), space: O(1). 
	* can we get better run time? say O(n) - we need to check every element at least once. use space to trade run time. I cannot find a solution.
2. Follow-up question
	* if n meeting overlaps at the same time, we need n meeting rooms. The problem becomes finding the max overlap count at any given point. 
	* DP doesn't seem to help because I cannot denote the formula of sub-problem. 
	* Another approach: say the integer really means time so we have total 24 hours. We can calculate the result for every single hour and choose the max one. It may not scale if we have unlimited bounds.

## Learning
1. For question #1, the discussion page has a better one - inside the comparison method, it checks the overlap and throw exception. The outer method caught and return true in that case.
2. For the follow-up question, the solution is,
	* sort start time to be an array
	* sort end time to be another array
	* one pointer to start end array and the other for end time array.
	* if start < end, we need a new room and move to next start.
	* if start > end, we know there is a room complete (because there's an end) so we don't need new room; but we need to move end to next position. `end` means next `earliest released room`.

#LC56 - Merge Intervals
source: https://leetcode.com/problems/merge-intervals/?tab=Description

*Given a collection of intervals, merge all overlapping intervals.*

For example,
```
Given [1,3],[2,6],[8,10],[15,18],
return [1,6],[8,10],[15,18].
```

## Analysis
1. Sorting is a great tool for interval problem.
2. Sort by start point and then iterate over the pairs.
3. If `current.End <= next.Start`, we should merge the pair so new pair becomes `[current.Start, next.End]`; **else** we reach a separate pair, so just need to add it to the result. 
5. Edge cases
	* in for-loop, let's compare current one with previous one.
	* if i == 0, initialize the result pair.
	* if i > 0, check current one with the result pair. 
		* if `current.Start <= resultPair.End`, update result pair end. **Update**: there's an edge case that the resultPair.End is bigger than current.End, so when merge, it actually does nothing. I made the mistake in the first submission. 
		* otherwise, add result pair to result list and initialize one to current pair.
	* After for-loop, we need to add result pair to result list.
	* Edge cases must be very careful.

## Learning
1. I use a `resultPair` to store previous result, but we can just use two variables `start` and `end` to avoid the object creation.
