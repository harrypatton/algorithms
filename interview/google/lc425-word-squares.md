source: https://leetcode.com/problems/word-squares/#/description

Requirements

1. all words have the same length
2. length is between 1 and 5.
3. chars are lower case English letters.

## Analysis
* naive solution
  * find all word combinations. n^m (m is the word length). check each square is O(s).
* optimized solution
  * consider word order as well.
  * if we use backtracking. 
  * I don't have a good solution for that.
  * Discussion page explained that a candidate must have a prefix. This is the key. See code below how to calculate that prefix.
  * Be careful, the word can be reused multiple times.

## Code without Trie
this solution is still slow because I didn't use trie. It spends a lot of time on `StartsWith` method. 
It is better to use a trie to return all strings with particular prefix.

See discussion page for solution using trie.

```c#
public class Solution {
	public IList<IList<string>> result = new List<IList<string>>();

    public IList<IList<string>> WordSquares(string[] words) {
    	int wordCount = words.Length > 0 ? words[0].Length : 0;
    	var wordList = new HashSet<string>();
    	foreach(var word in words) wordList.Add(word);

    	foreach(var word in wordList) {
    		var subResult = new List<string>();
    		subResult.Add(word);
    		Check(subResult, wordList, wordCount);
    		// order matters
    		subResult.RemoveAt(subResult.Count - 1);
    	}

        return result;
    }

    public void Check(IList<string> subResult, HashSet<string> wordList, int wordCount) {
    	// find a match. add to result.
    	if(subResult.Count == wordCount) {
    		result.Add(new List<string>(subResult));
    		return;
    	}

    	string prefix = "";
    	int index = subResult.Count;
    	foreach(var w in subResult) prefix += w[index];

    	foreach(var w in wordList) {
    		if (w.StartsWith(prefix)) {
    			subResult.Add(w);
    			Check(subResult, wordList, wordCount);
    			// order matters
    			subResult.RemoveAt(subResult.Count - 1);
    		}
    	}
    }
}
```
