#Map Implementation
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
