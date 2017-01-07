#Question
**Objective**: Given array of n integers and given a number X, find all the unique pairs of elements (a,b), whose summation is equal to X.

#Ideas
I thought about two solutions (naive, sort+binary search), but other people come up with another 2 ways. I feel great to learn the ways I don't know :-).

##Approach 1
The naive way to do this would be to check all combinations (n choose 2). This exhaustive search is O(n2).

##Approach 2
 A better way would be to sort the array. This takes O(n log n) 
Then for each x in array A, use binary search to look for T-x. This will take O(nlogn).
So, overall search is  O(n log n)

##Approach 3 
The best way would be to insert every element into a hash table (without sorting). This takes O(n) as constant time insertion.
Then for every x, we can just look up its complement, T-x, which is O(1).
Overall the run time of this approach is O(n).

##Approach 4
very similar to #2 but we don't use binary search to look for T-x. Why?

Given a sorted array, let's set two indexes in start and end.

1. if array[start] + array[end] == T, we found the result.
2. if array[start] + array[end] > T, end = end - 1. Why? end element is too big and won't get the expected sum with any given start, so it becomes subproblem for [start, end - 1].
3. if array[start] + array[end] < T, start = start + 1. Why? start element is too small even given the biggest end. It becomes problem to [start + 1, end]
4. Use recursion to solve sub-problem from #2 and #3.

#Learning
I was confused by approach #4 in the beginning. E.g., when array[left] + array[right] > T, we can either move right cursor to left, or move left cursor to left, or both. Why we just move right cursor only? I understood when I thought about the subproblem concept. We always come up with a subproblem to solve and moving left cursor to left is invalid in subproblem context (i.e., left cursor is the first element in array and you cannot move to left.)

The same confusion happened when worked an question which find an element in a 2-dimensional sorted array. The algorithm searches element from top-right element. 

* if top-right element < expected value, it moves down one step and eliminates the whole row above. Why not move to right? There's no right to move for top-right element.
* if top-right element > expected value, it moves left one step and eliminates the whole column. Why not move to up? cannot move for top-right element.
* in above calculation, we exclude one row or column. It becomes a subproblem with a smaller matrix and we can still repeat the same process and the test element is still the top-right element.


#Reference
1. http://stackoverflow.com/questions/4720271/find-a-pair-of-elements-from-an-array-whose-sum-equals-a-given-number
