#438 Find All Anagrams in a String
Source: https://leetcode.com/problems/find-all-anagrams-in-a-string/

An `anagram` is a type of word, the result of `rearranging` the letters of a word or phrase to produce a new word or phrase, using `all the original letters exactly once`. For example: `orchestra` can be rearranged into `carthorse` or `cat` can be rearranged into `act`.

**Problem**: Given a string `s` and a non-empty string `p`, find all the start indices of `p's` anagrams in `s`.

Strings consists of lowercase English letters only and the length of both strings s and p will not be larger than 20,100.

##Ideas
### Brutal Force #1
1. Calculate all anagrams for `p`.  Assume the string length is n, time complexity is `O(n!)`.
2. Find index for the anagram string in `s`. O(m+n). The string length of `s` is m.

total time complexity: O((m+n) * n!).

### Better Solution
1. Check all substrings in `s` which length is equal to `p`. Time complexity: `O(m - n + 1)`. `m` is the length of `s`; `n` is the length of `p`.
2. Verify if they are anagram strings. We can sort and then check. Time complexity O(nlogn).

total time complexity: O((m-n+1) * n * logn).

Do we have a better way to check anagram string? If we use hash table, the time could be O(n) but with O(n) space. Total time complexity for the problem is `O((m-n+1) * n)`.

##Learning
1. **Discussion page shows an O(n) solution but I don't understand it. I'll revisit it later.**
