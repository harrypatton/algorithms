# LC524 - Minmum Number of Deletions of a string
Source

* http://blog.gainlo.co/index.php/2016/04/29/minimum-number-of-deletions-of-a-string/
* https://leetcode.com/problems/longest-word-in-dictionary-through-deleting/#/description

*Given a dictionary and a word, find the minimum number of deletions needed on the word in order to make it a valid word.*

For example, string “catn” needs one deletion to make it a valid word “cat” in the dictionary. And string “bcatn” needs two deletions.

## Analysis
1. **Travel the dictionary**: compare the word with every single word in the dictionary. The dictionary word must find all letters in the string in the same order. Through brutal force, I find something interesting. We need to scan every single word in the dictionary. It is something we cannot avoid.
	* should we sort the dictionary or not? I'm not sure for now.
	* Given two words, how to make sure deletion in the first word can make it to be the second word? and how many deletions?
		* Use two pointers to compare. If chars are equal, move both pointers; otherwise move the first pointer. The count is length difference. The second pointer must be reach beyond the last so that we can say deletion work.
	* Complexity: time O(n^2), space O(1).
	* **Update**: I don't find sorting can help. I don't find optimal solution either.
2. **Travel the word**: it is the second solution in source. Instead of checking every word in dictionary, we can get all possible words by remove letters and then check if exist in dictionary. 
	* dictionary look up is O(1)
	* the word has O(2^n) combinations after deleting letter.
	* Time O(2^n). 

**Update**: one time bug free code.

#Find The Longest Substring With K Unique Characters
source: http://blog.gainlo.co/index.php/2016/04/12/find-the-longest-substring-with-k-unique-characters/

*Find the longest substring with K unique characters.*

Take string “aabbccdd” as an example.
if K is 1, the longest substring can be “aa”.
If K is 2, the longest substring can be “aabb”.
If K is 3, the longest substring can be “aabbcc”.

## Analysis
1. The first idea coming in mind is sliding window with start and end point.
2. A hash table (or array) and counter will be used to track how many unique characters there're. 
3. When the window has more than K unique chars, we move start; otherwise we move end.
4. When do we quit the loop? `end == array.Length -1 && end - start + 1 < k`
5. Time O(n), Space O(1) (26 char array) or O(k) (using hash table) 
6. Base case
	* `if k <= 0, result = string.Empty`
	* `if str == null || str.Length == 0, result == string.Empty`
	* `if k > str.Length, result = string.Empty`

Signature
```
public string FineLongestSubstring(string str, int k)
```

## Learning
1. The code is easy but I missed quite a few edge cases. I mind-debugged a few times but still failed to catch the bug. It is a shame and I need to be careful.
