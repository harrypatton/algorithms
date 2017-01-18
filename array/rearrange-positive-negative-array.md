#Origin
* http://algorithms.tutorialhorizon.com/rearrange-positive-and-negative-numbers-of-array-on-each-side-in-onlogn/
* http://www.geeksforgeeks.org/rearrange-positive-and-negative-numbers/
* 

#Overview
**Objective**: rearrange positive and negative numbers of an array so that one side you have positive numbers and other side with negative integers **without** changing their respective order.

#Ideas
The optimal way is probably similar to quick sort with a pivot.

##naive solution
1. find how many positive numbers first.
2. index for positive is 0, and the index for negative is from #1.
3. scan the whole array and add the data in respective index.

* time complexity: O(n)
* space complexity: O(n) we use a new array.

##insert sort
1. scan the array
2. if it is positive number, do nothing
3. if it is negative number, scan the rest of array and find a positive number. 
4. all numbers from the negative number until the one before positive one, shift right one position
5. positive one comes to the previous negative number position.

time: O(n^2)

##divide and conquer - merge solution
O(n) is the best time we can get because we need to check each integer. We can improve the space.

Let's say we still scan first and calculate how many positive numbers we have.

Use a divide and conquer - similar to merge sort

1. Divide the array into two halves and calculate each part.
2. Merge the result. This is the tricky part.

Merging: (Negative on left side and positives on the right side)

1. Navigate the left half of array till you won’t find a positive integer and reverse the array after that point.(Say that part is called ‘A’)
2. Navigate the right half of array till you won’t find a positive integer and reverse the array before that point. (Say that part is called ‘B’)
3. Now reverse the those parts from both the array (A and B).

Time complexity is O(nlog(n)); each tree layer we move n elements twice.
O(logn) space because of recursive calls.

#Learning
