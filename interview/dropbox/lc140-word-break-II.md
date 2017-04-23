source: https://leetcode.com/problems/word-break-ii/#/description

Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, add spaces in s to construct a sentence where each word is a valid dictionary word. You may assume the dictionary does not contain duplicate words.

Return all such possible sentences.

For example, given
```
s = "catsanddog",
dict = ["cat", "cats", "and", "sand", "dog"].
A solution is ["cats and dog", "cat sand dog"].
```

```csharp
/*
1. backtracking - to get result, we usually have to use backtracking to get the result. Unfortunately I get TimeOut exception.
2. Go back to DP - use dictionary to store some results.

Why backtracking doesn't work? Because there're a lot of duplicate sub-problems.
*/
public class Solution {
    
    private Dictionary<string, IList<string>> cache = new Dictionary<string, IList<string>>();
    
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        if (s == null) return new List<string>();
        
        if (cache.ContainsKey(s)) return cache[s];       
        
        var result = new List<string>();
        
        foreach(var word in wordDict) {
            if (s == word) {
                result.Add(s);
            } else if (s.StartsWith(word)) {
                var subResults = WordBreak(s.Substring(word.Length), wordDict);
                
                if (subResults.Count > 0) {
                    foreach(string subResult in subResults)
                        result.Add(word + " " + subResult);
                }
            }
        }

        cache[s] = result;
        return result;
    }
}
    
    /* backtracking solution
    
    private IList<string> result = new List<string>();
    
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        WordBreak(s, wordDict, new List<string>());
        return result;
    }
    
    public void WordBreak(string s, IList<string> wordDict, IList<string> preResult) {
        if (s == "") {
            result.Add(string.Join(" ", preResult));
        }
        
        for(int i = 1; i <= s.Length; i++) {
            var word = s.Substring(0, i);
            if (wordDict.Contains(word)) {
                preResult.Add(word);
                WordBreak(s.Substring(i), wordDict, preResult);
                preResult.RemoveAt(preResult.Count - 1);
            }
        }
    }
    */

```
