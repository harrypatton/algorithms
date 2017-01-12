#Origin
* http://www.geeksforgeeks.org/longest-common-prefix-set-1-word-by-word-matching/
* http://www.geeksforgeeks.org/longest-common-prefix-set-2-character-by-character-matching/

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

#Learning
