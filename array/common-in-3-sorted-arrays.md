#Origin
* http://algorithms.tutorialhorizon.com/find-all-common-numbers-in-given-three-sorted-arrays/

#Overview
**Objective**: 
Given three sorted ascending order arrays of integer. find out all the common elements in all arrays.

#Ideas
##Naive solution - brute force
1. Pick up the shorted array
2. Iteration on that array
	* use binary search to check if the char exists in other arrays.

Assume each array has similar length, binary search is O(n) and we scan the whole array, so total time complexity is O(nlogn). 

##Optimal solution - move pointers on each array
1. Put 3 pointers to each head of arrays
2. If all pointed elements are equal, add to result. Each pointer moves forwards.
3. Otherwise, move forward the pointer which has the minimum value.
4. If one pointer beyonds the boundary, exit; otherwise go to #2.

Time complexity: O(n1 + n2 + n3).

