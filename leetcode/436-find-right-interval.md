#436 - Find Right Interval
source: https://leetcode.com/problems/find-right-interval/

The problem description is a little bit long but still easy to understand. Just note,

* each interval is a two-element array (start, end)
* for an interval end point is always bigger than start point.
* no two intervals have the same start point.

## Ideas
### Brutal Force
It is easy to think of brutal force. Pick up one element and compare with others to find the minimum right interval. Time complexity is O(n^2).

### DP?
Say we already have the result for `n-1`. When add a new element, compare each element to see if any other minimum value. Still the same time complexity O(n^2).

### Change data structure
what if we have (start, length)? It doesn't help.

### Sort?
How about sort? 

1. After sorting, the order is changed so we wouldn't know the index.
2. sorting by start or end point? It is kind of hard.

**Update** after going through other solutions, I'll come back to this one.

1. Create array #1 to sort the input by Start point.
2. Use hash table to store a mapping between start point and index.
3. Iterate original array, for each element,
	* in array #1, use binary search to find an element's start point is just greater than current element's end point. 
	* use hash table to find the index and save in result.
4. we can also use one structure to combine #1 and #2.

Time complexity: O(nlogn).
