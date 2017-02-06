#447 Number of Boomerangs
source: https://leetcode.com/problems/number-of-boomerangs/

Given `n` points in the plane that are all pairwise distinct, a "boomerang" is a tuple of points (`i, j, k`) such that the distance between `i` and `j` equals the distance between `i` and `k` (**the order of the tuple matters**).

Find the number of boomerangs. You may assume that n will be at most 500 and coordinates of points are all in the range [-10000, 10000] inclusive.

#Idea
##Brutal Force
The first idea is brutal force. 

1. Pick up any element as the start point
2. Calculate the distance with other elements. Save the result `distance => count` in a hash table.
3. Enumerate the hash table
	* if count == 2, it is 2 (order matters)
	* if count == 3, result is `3 * 2`, i.e., 6.
	* if count == n, result is `n * (n-1)`. Because there're two positions, the first one has n choices and the next is (n-1) choices.
4. Finish the part for all elements in the array.

Complexity

* time: every element is O(n) (scanning other elements) + O(n) (checking with hash table), so total is O(n^2).
* space: hash table -> O(n).

##Optimal Solution
1. we need to calculate distance.
2. if we know distance(a, b) and distance(a, c), we still don't know distance(b, c). It means we have to calculate the distance of every single pair, i.e., time complexity is O(n^2).
3. if we know distance(a, b) then we know distance(b, a).
4. Given a collection of pairs which have the same result, how to get boomerangs? Sort by the beginning, calculate the result; sort by the end, calculate the result. It still involves sorting.

**Summary**: I cannot find a better solution yet.

#Learning
1. Discussion page doesn't show any better solution. One optimal part is, when calculate the result, we don't have to get the real distance (i.e., call Sqrt method). Saving the value of (a^2 + b^2) is good enough to be dictionary key.
