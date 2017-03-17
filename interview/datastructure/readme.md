# Map Implementation
source: http://blog.gainlo.co/index.php/2016/08/14/uber-interview-question-map-implementation/

*Implement data structure “Map” storing pairs of integers (key, value) and define following member functions in O(1) runtime: void insert(key, value), void delete(key), int get(key), int getRandomKey().*

## Analysis
1. Data structure design is very interesting question to ask.
2. What does `insert` mean for duplicate elements? update the value as dictionary does?
3. It mentions `map` so can we just use `dictionary` which is based on hash table?
	* `insert`, `delete` and `get` can be done in O(1).
	* `getRandomKey`
		* as long as we have an array to store all keys, it is easy to get a random one.
		* probably we should maintain another hash table, the key is 1, 2, 3, 4 and the value is the original key. When insert a new pair, we increase the counter and add to the 2nd hash table. **Issue**: when delete an original key, how could it be O(1) operation?
		* we can use List which has atomized complexity O(1). When delete a key, we swap it with last element and keep the count reduced by 1. **we need to find the key first, so how to do that?** We need another hash table to store the index in array.
4. think about the problem through another way,
	* the question mentions integer pair so it is a constraints we can use.
	* `get`: here's a few options,
		* hash-based solution.
		* key is the index of an array.
	* `delete`: if we get `get` in O(1), we can make `delete` happen.
	* `insert`: still need to check if one exists, so it depends on `get` again.
	* `getRandomKey`: how to maintain an array in O(1)? use List. Although it needs to expand the array but worst case is still O(1).
5. Tree operation is usually O(logn) so it is not a good data structure for this problem.

## Learning
1. I came up with the same solution as in source page.

# LC - Two Sum III - Data Structure Design
Source: [1](http://www.programcreek.com/2014/03/two-sum-iii-data-structure-design-java/), [2](http://www.cnblogs.com/grandyang/p/5184143.html), [3](https://discuss.leetcode.com/category/178/two-sum-iii-data-structure-design)

*Design and implement a TwoSum class. It should support the following operations: add and find.*

`add` - Add the number to an internal data structure.
`find` - Find if there exists any pair of numbers which sum is equal to the value.

For example,
```
add(1); 
add(3); 
add(5);
find(4) -> true
find(7) -> false
```

## Analysis
I like this kind of question. It is easy to understand and also test data structure and algorithm. 

 Solution | Add | Find  | Space
 ------------- |-------------| ----- | ----
 Add the item to an array; calculate all sum and save in a hashset. | time O(n) | time O(1) | array O(n), hash O(n^2)
 Add the item to an array; save it in a hashset; in `find`, go through the array and check if any `sum-element` exists in hashset. Need to handle `sum = 2 * element case` (i.e., track item count in dictionary.)      | time O(1)   |   time O(n) | array O(n), hash O(n)
  Add the item to an array. in `find`, check every two elements  | time O(1) | time O(n^2)      | array O(n), no hash.
 Add the item to a sorted array. in `find`, use two pointers start and end to scan.  | time O(logn) | time O(n)      | array O(n), no hash.

That's all solutions I can think of for now. The best solution is the 2nd one depending on the requirements.

**Update**: my analysis is better than most forum threads. I also cover more solutions.
