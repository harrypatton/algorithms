# LC242 - Valid Anagram
source: https://leetcode.com/problems/valid-anagram/?tab=Description

Given two strings s and t, write a function to determine if t is an anagram of s.

For example,
```
s = "anagram", t = "nagaram", return true.
s = "rat", t = "car", return false.
```

## Analysis
1. **Sort**: sort both strings. If it is anagram, both are equal. `Time O(nlogn)`.
2. **Array or Hash Table**: we can use 26 or 256 length char if the letter is English or ASCII letters.
	* Length should be equal.
	* scan the first string to initialize the hash table
	* scan the second string. Reduce the count for existing letter. if the letter doesn't exist or count becomes negative, it is not an anagram. 
	* complexity: time O(n), space O(n).
	* ok, the problem shows it only has lowercase alphabets (i.e., lowercase English letters), so we can use 26-length array.
	* **Note**: the problem checks if the string **is** an anagram of another string. It doesn't say if a string **contains** an anagram of another string. It is a slightly different problem.

# LC438 - Find All Anagrams in a String
source: https://leetcode.com/problems/find-all-anagrams-in-a-string/?tab=Description

**Problem**: Given a string `s` and a non-empty string `p`, find all the start indices of p's anagrams in s. Strings consists of lowercase English letters only and the length of both strings s and p will not be larger than 20,100.

# Analysis
1. **Brutal force** - find all substrings having the same length as `p`, and then check if it is anagram.
	* finding all substring O(n)
	* check if an anagram: O(n)
	* total O(n^2)
2. **Moving Window**
	* We need a list to store each letter count for an anagram.
	* We need some variables to track how close current string is close to an anagram.
		* a list to track each letter count for current window.
		* a variable `counter` to track how close we're.
		* when add a letter to moving window (i.e, the end element)
			* we minus 1 in the 2nd list.
			* if the letter exists in the 1st list and new count `>= 0 && < original count`, the `counter` minus 1. If `counter == 0`, we find an anagram.
		* when remove a letter in moving window (i.e., the start element)
			* we add 1 in the 2nd list.
			* if the letter exists in the 1st list and new count `> 0 && <= original count`, the `counter` add 1.
	* After the first substring, we move one step at a time.

** Update**: my solution O(n) passed the test; but the code is not clean at all. We just need one list and modify the counter based on some conditions.

#LC49 - Group Anagrams
Source

* https://leetcode.com/problems/anagrams/#/description
* http://blog.gainlo.co/index.php/2016/05/06/group-anagrams/

*Given a set of random string, write a function that returns a set that groups all the anagrams together.*

For example, suppose that we have the following strings:
“cat”, “dog”, “act”, “door”, “odor”

Then we should return these sets: {“cat”, “act”}, {“dog”}, {“door”, “odor”}.

##Analysis
* Check if two strings are anagrams. There're two ways,
	* To check if two strings are anagram, we use hash table to do the work. If the chars comes from a restricted charset (e.g., lower-case English letter), we can use array instead of hash table.
	* Another way to check anagram is to sort the string and check if they are the same.
* **Brutal force** - pick up every string and compare with others. O(n^2*m). m means anagram checking time (when use hash table or array).
* **Sorting** - sort the string based on sorted value. It is O(mlogm*nlogn). m is the string length. After that O(n * m) to get the result.
* **Dictionary** - if we use array to store each char counter, we can calculate a key string used in dictionary.  convert the 26-length array to string like, 0,0,0,2,1,3,.... Time complexity is O(n*m). Space O(m)

Signature
```
public IList<IList<string>> GetGroups(IList<string> strings)
```

**Update** - dictionary solution is much easier to write than the sorting one. Bug free one time pass. 
