##Original Post
* http://algorithms.tutorialhorizon.com/find-kth-smallest-or-largest-element-in-an-array/
* http://www.geeksforgeeks.org/kth-smallestlargest-element-unsorted-array/ 

##Problem
Find kth smallest element in an array

##Ideas
###Naive solution - loops
ForEach n in 1 .. K, scan the array to find the nth smallest. In each loop, we already know the closest smallest element, so we can find nth smallest element.

Time complexity: O(nk).

###Naive solution - sorting
Sort the array and scan for the kth smallest element. 

Time complexity is O(nlogn).

###Solution - max heap
1. Maintain a max heap with max 6 elements
2. Iterate the array
	* if heap is not full, add the element. Biggest element is on top (i.e., max heap).
	* if heap is full,
		* if element >= heap top element, ignore.
		* if element < heap top element, pop top and add element to heap.

I remember adding element to max heap is O(logk), so the total time complexity is O(nlogk).

###Solution - quick sort
1. Choose first value as pivot one.
2. Move elements around. smaller ones go to left side and bigger ones go to right side.
3. Check if pivot element is at kth position.
	* If yes, return
	* If no and before kth position, pick value after it and repeat the process.
	* If no and after kth position, pick value before it and repeat the process.

It seems time complexity is O(nlogn). 
**correction**: worst case O(n2), average O(n)

###Solution - check wikipedia
apparently there is a lot of O(n) algorithm. check [wiki](https://en.wikipedia.org/wiki/Selection_algorithm).
