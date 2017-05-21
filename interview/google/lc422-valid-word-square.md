source: https://leetcode.com/problems/valid-word-square/#/description

Given a sequence of words, check whether it forms a valid word square.

A sequence of words forms a valid word square if the kth row and column read the exact same string, 
where `0 ≤ k < max(numRows, numColumns)`.

## Analysis
The following code is based on prefix checking from lc424. Apparently it becomes more complicated than discussion page solution.
Feel free to check that one. My brain doesn't work at this point.

```c#
public class Solution {
    public bool ValidWordSquare(IList<string> words) {
        if (words == null || words.Count == 0) return false; // empty

        var count = words[0].Length;
        if (count != words.Count) return false; // not a square
        var preCount = count;

        for(int i = 1; i < count; i++) {
        	if (words[i].Length > preCount) return false;
        	else preCount = words[i].Length;

        	var prefix = new StringBuilder();
        	bool checkPrefix = true;
        	for(int j = 0; j <= i - 1; j++) {
        		if (i < words[j].Length) prefix = prefix.Append(words[j][i]);
        		else {
        			checkPrefix = false;
        			break;
        		}
        	}

        	if (checkPrefix) {
        		if(!words[i].StartsWith(prefix.ToString())) return false;	
        	} else {
        		if (words[i] != prefix.ToString()) return false;
        	}
        	
        }

        return true;
    }
}
```
