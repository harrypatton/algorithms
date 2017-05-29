## Problem
Source: https://leetcode.com/problems/generalized-abbreviation/#/description

Write a function to generate the generalized abbreviations of a word.

Example:
```
Given word = "word", return the following list (order does not matter):
["word", "1ord", "w1rd", "wo1d", "wor1", "2rd", "w2d", "wo2", "1o1d", "1or1", "w1r1", "1o2", "2r1", "3d", "w3", "4"]
```

## Analysis
it is a little hard to understand the problem. 
It seems to use number to represent any number of characters.
Note that, we can use two abbreviation continuously. There must be some characters to separate.

I was struggling with backtracking, recursion or potential DP when wrote the code. It was hard to tell which one is better. Actually backtracking is a type of recursion but the code could be clean.Backtracking always gets partial result and thinks about next step. Recursion is to break down the problem into small ones.
In this case, backtracking is easier to calculate time complexity.

My original thought: let's use recursion.
1. last char shows as a char.
2. last one shows as part of number.
3. how to avoid duplication?

**Time complexity**
`f(n) = f(n-1) + f(n-2) + ... + f(1) => f(n) = O(n^2). We can calculate from f(1), f(2), f(3) ...`

## Code - Backtracking
```java
  public List<String> generateAbbreviations(String word){
        List<String> ret = new ArrayList<String>();
        backtrack(ret, word, 0, "", 0);

        return ret;
    }

    private void backtrack(List<String> ret, String word, int pos, String cur, int count){
        if(pos==word.length()){
            if(count > 0) cur += count;
            ret.add(cur);
        }
        else{
            backtrack(ret, word, pos + 1, cur, count + 1);
            backtrack(ret, word, pos+1, cur + (count>0 ? count : "") + word.charAt(pos), 0);
        }
    }
```

## Code - Recursion
```c#
public class Solution {
    public IList<string> GenerateAbbreviations(string word) {
        var result = new List<string>();        
        if (word != null && word.Length > 0) {
            result.AddRange(StartWithChars(word));
            result.AddRange(StartWithNums(word));
        } else result.Add("");

        return result;
    }

    public IList<string> StartWithChars(string word) {
        var result = new List<string>();
        for(int len = 1; len <= word.Length; len++) {
            var str = word.Substring(0, len);
            var parts = StartWithNums(word.Substring(len));
            if (parts.Count == 0) result.Add(str);
            foreach(var part in parts) {
                result.Add(str + part);
            }
        }

        return result;
    }

    public IList<string> StartWithNums(string word) {
        var result = new List<string>();
        for(int len = 1; len <= word.Length; len++) {
            var parts = StartWithChars(word.Substring(len));
            if (parts.Count == 0) result.Add(len.ToString());
            foreach(var part in parts) {
                result.Add(len.ToString() + part);
            }
        }

        return result;
    }
}
```
