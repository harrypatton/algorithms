#LC524 - Minmum Number of Deletions of a string
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
