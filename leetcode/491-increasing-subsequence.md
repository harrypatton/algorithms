#Source
https://leetcode.com/problems/increasing-subsequences/

#Question
Given an integer array, your task is to find all the different possible increasing subsequences of the given array, and the length of an increasing subsequence should be at least 2 .

#Clarification
* array length <= 15
* element range [-100, 100]
* subsequence doesn't have to be a continuous sub-array.
* may contain duplicates, and two equal integers are considered as increasing subsequences.

#Idea
## solution - recursion
1. Assume we have result for 1..n-1, f(n-1).
2. f(n) is the combination of 3 parts
	* f(n-1) itself
	* 2-element pair ending with nth element. It needs to scan 1..n-1.
	* iterate every subsequence in f(n-1). If the last element of subsequence <= nth, add a new subsequence ending with nth element.
3. Eliminate the duplicate result from above step #2.

worse case happens when the array is sorted in ascending order. 

Time: f(n) = f(n-1) + n + f(n-1). f(n) = 2f(n-1) + n, so it is O(2^n). (I'm not very sure)

#Learning
1. Cannot find a good solution other than recursion.
2. Got stuck in edge cases until cleared the mind and tried it again. 
3. ``I'm pretty sure there's a better way than my solution; but solution on Leetcode is not well explained. Look forward to better comments.``
