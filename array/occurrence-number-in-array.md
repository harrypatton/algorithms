#Origin
* http://algorithms.tutorialhorizon.com/find-the-number-of-occurrences-of-a-number-in-a-given-sorted-array/

#Overview
**Objective**: 
Find the number of occurrences of a number in a given sorted array.

#Ideas
##Naive solution - brute force
search from first element to find the number and then count how many occurrences. 
time = O(n), n is array length

##Better solution - binary search 1
use binary search to find the element. Scan from both directions. 
time = O(m), m is max occurrences.

##Optimal solution - binary search to identify start/end positions
1. use binary search to find number n-1 and n+1.
2. be careful about the edge scenario. 
	* When the number is not found, where is final pointer? there are 2 scenarios - left == right and left + 1 == right.
	* if the number is found, is there only one?

``The above idea is not correct. It falls back to original problem when found n-1 or n+1.``

The idea is still the same, but need a better way to find boundary. When we found the number, regular binary search just quit. What if we don't quit?

1. use binary search to find number n
2. find the left boundary
	* if array[middle] = n, right = middle - 1.
	* if array[middle] > n, right = middle - 1.
	* if array[middle] < n, left = middle + 1.
	* when left > right, choose the right value.
3. find the right boundary
	* if array[middle] = n, left = middle + 1.
	* if array[middle] > n, right = middle - 1.
	* if array[middle] < n, left = middle + 1.
	* when left > right, choose the left value.
4. final result: [left index] - [right index] - 1. E.g., len(0, 2) = 1, len(0, 1) = 0

time complexity: O(logn)

It takes me a few minutes to find the solution.

##Learning
Original post shows a little more optimal solution,

```
How do you find the first occurrence of a number using binary search.

Put one additional condition in the step when array[mid]==x, just check whether the element prior to mid is smaller than the x, if yes then only return the mid index, this will give you the first occurrence. handle the boundary conditions.
```
