#451 - Sort Characters By Frequency
source: https://leetcode.com/problems/sort-characters-by-frequency/

Given a string, sort it in decreasing order based on frequency.

Note: the character is case sensitive. E.g, `a` and `A` are different letters. When two letters have the same frequency, the order doesn't matter.

## Idea
### Brutal Force
1. Use a hash table Dictionary<char, int>.
2. Scan the string and save the frequency in the hash table.
3. Sort the hash table by the value in descending order. (convert hash table to list and then sort).
4. Write out the letter based on the order.

Complexity
* time: O(nlogn) due to the sort algorithm.
* space: O(n)

### Bucket Sort
Discussion page shows another solution with better time complexity but definitely worse space complexity.

1. We still need to build up the map.
2. This is the tricky part to use bucket sort.
	* create a new array which has the same length as input string. Each element is a string type.
	* Iterate the maps from #1
		* `value - 1` is the index on new array. `array[value - 1] += new string(key, value)`. The string constructor means create a string with a number of the same chars.
3. Scan the new array from end to start. Append the element which is not empty or null string.

Conclusion: it is O(n) time complexity but it uses a lot of memory. When input string length is very large and there're a lot of frequent chars, it wastes large memory compared with sort algorithm.
