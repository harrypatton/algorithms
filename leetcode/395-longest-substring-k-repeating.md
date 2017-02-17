#395. Longest Substring with At Least K Repeating Characters

Source: https://leetcode.com/problems/longest-substring-with-at-least-k-repeating-characters/

**Problem**: given a string and number `k`, find the length of `longest` substring in which every char repeats at least `k` times.

## Analysis
### Brutal Force
1. find all substring
2. calculate if the substring meets the requirement.
3. update max length.

how many substrings? 1 + 2 + 3 + ... n = O(n2). Checking takes O(n), so total time complexity is `O(n ^ 3)`.

### DP
1. take the last letter. It is either in the longest substring or not. **cannot break down into sub-problems** here.

### Other Solution
1. Scan the string and calculate the count.
2. If every letter has at least `k` times, we're done. The string length is the result.
3. It means longest substring shouldn't include any letter which count < `k`. 
4. It becomes easy now. It is more like longest word in a string. **funny**: when I were writing the code, I realized I'm wrong. The string is definitely there but not every string could meet the condition because the char could be in another string.
5. I use recursion to find the substring after #4 has a list of chars we need to exclude.

time complexity: I don't know:). 

##Learning
1. It is the same idea as in discussion page. It is called `divide and conquer`.
2. Because the letter is just English letter, we can use an array with 26 chars.
3. We don't have to split in multiple substrings. We can find the first `less` char and then use it to divide the string. 
