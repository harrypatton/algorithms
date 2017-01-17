#Origin
* http://www.geeksforgeeks.org/longest-common-prefix-set-1-word-by-word-matching/
* http://www.geeksforgeeks.org/longest-common-prefix-set-2-character-by-character-matching/
* http://www.geeksforgeeks.org/longest-common-prefix-set-3-divide-and-conquer/
* http://www.geeksforgeeks.org/longest-common-prefix-set-5-using-trie/

#Overview
**Objective**: 
Given a set of strings, find the longest common prefix.

```
Input  : {“geeksforgeeks”, “geeks”, “geek”, “geezer”}
Output : "gee"

Input  : {"apple", "ape", "april"}
Output : "ap"
```

#Ideas
##Solution 1 - word by word
1. Find common prefix for 1st and 2nd strings.
2. Use common prefix from #1 to compare with 3rd string.
3. Repeat #2: use current common prefix to compare with next string in the string set.

###Complexity
* Time: O(m*n). m is string count and n is largest string length.
* Space: O(n). n is the largest string length.

##Solution 2 - char by char
1. Check the first letter from all strings. If equal, go to #2; otherwise stop.
2. Check next letter from all strings. If equal, repeat this step until no more letter from one string; otherwise stop.

###Complexity
It is the same as previous one.

If there are a huge amount of strings and reading is slow, the "word by word" solution is better because it doesn't need to scan all strings over and over again. In distributed system, it doesn't matter.

##Solution 3 - divide and conquer
1. Find common longest prefix in first half
2. Find common longest prefix in second half
3. Find the result between #1 and #2.

###Complexity
* Time: n*m (bottom layer) + n*m/2 + n*m/4 + .. + n(top layer) = n * m * (1 + 1/2 + 1/4 + ...) = n*m. so it is O(n*m). n is largest string length and m is string count.
* Space: O(nlogm) -> recursive methods

##Solution 4 - use trie
build up the trie and then walk from the root until find the first node which has branches.

#Learning
