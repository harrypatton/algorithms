#Origin
* http://www.geeksforgeeks.org/find-smallest-value-represented-sum-subset-given-array/

#Overview
**Objective**: 
Given a sorted array of positive integers. Find min value that cannot be represented as sum of any sub-array of this array.

single element array is considered as sub-array too.

#Ideas
##Naive solution
1. Get all possible sub arrays.
2. Calculate the sum and sort them
3. Scan from the min one.
4. if there is no continuous number, it is min value.

time: O(2^n).

##Better solution
I didn't figure it out in the first time.

After reading the original post, apparently there's a trick there.

1. Scan from the first element until the last one.
2. Say we're handling elements[i] and previous max sum is sum (i.e., we can get 1 .. sum as sum of any sub-array).
	* if elements[i] > sum + 1, then return sum + 1.
	* else all sum results could be 1 .. sum + elements[i] (a little bit tricky to get the conclusion), so the sum = sum + elements[i]. Go back to #2.

#Learning
