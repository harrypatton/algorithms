##Original Post
* http://algorithms.tutorialhorizon.com/find-intersection-between-two-sorted-arrays/

##Problem
Given two sorted arrays, find intersection point between them.

##Ideas
###Naive solution - loops
Pick every element in one array and check if exists in another array.

Time complexity: O(m*log(n)). The second part can use binary search.

###Adjusted Merge Sort
Similar to merge sort algorithm,
* put two indexes in the head of each array
* If element[i] == element[j], it is an intersection point and move both indexes.
* If element[i] < element[j], i ++;
* if element[i] > element[j], j ++;

Time complexity: O(m+n). Space: O(k). K is the number of intersection points.

##Note
Easy question.
