Title: Box Stacking

#Objective
Given a set of 3D boxes. The nth box has height h(n), width w(n) and depth(n). Create a box as tall as possible with rules

* you can rotate the box.
* the surface (i.e., 2D) on bottom box must be larger than the above one.
* you can use multiple instances of the same type of box (by using different surface).

#Ideas
##Brutal force

Intuitive/naive solution,

1. Calculate every possible surface of all boxes.
2. sort the size by ascending.
3. The result is tallest boxing stack.

Step #2 is the problematic one. Unlike size, we cannot always find the ascending order, e.g., a rectangle and a square. Which one is bigger? Another issue is, we need to check 3rd dimension when surface is the same. In this case, we have to try all different possibilities (i.e., 2^n, n is the total count of surface).

Data structure: an array of element (h, w, d).

##Recursion
1. f(box,h,w,d) = tallest stacking when this box stays in the bottom.
2. start from smalling box, we're going to have a few f(x1) = h1, f(x2) = h2.
3. When calculate f(xn), assume x1, x2, .., xn-1 are smaller than xn, it just needs to pick up the max one.

First sorting by area and then run the recursion. It is ok because step #3 will check if it is absolutely smaller via depth and width.

* If a box area >= current one, it should not be on top.
* Otherwise, it **may** sit above.

##DP
See recursion. I realize I always come up with DP solution first :-).

###Complexity
* Time: O(n^2). Each box has to check all "possible" smaller box for its result.
* Space: O(n)

###Note
* The solution on tutorialhorizon is correct, but the description is a little confusing when talk about condition. Geeksforgeeks is better.

#Reference
* http://algorithms.tutorialhorizon.com/dynamic-programming-box-stacking-problem/
* http://www.geeksforgeeks.org/dynamic-programming-set-21-box-stacking-problem/
