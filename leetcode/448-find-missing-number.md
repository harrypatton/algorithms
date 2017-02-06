#448 - Find All Numbers Disappeared in an Array
source: https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/

Given an array of integers where `1 ≤ a[i] ≤ n` (n = size of array), some elements appear twice and others appear once.

Find all the elements of [1, n] inclusive that do not appear in this array.

Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.

#Idea
1. It is easy to use hash table or sort to solve the problem with either O(nlogn) runtime or O(n) space. I cannot think of any data structure to support O(n) run time without extra space.

#Learning
After reading discussion page, it uses a trick to get the result. 

1. iterate all numbers in the array
2. Say the number is x, how to set a flag that the array has number x? We set negative flag in the xth element in the array. If xth element is already negative, do nothing.
3. After that, iterate the array again. If the element is position, the `index + 1` is the number missing in the array.
