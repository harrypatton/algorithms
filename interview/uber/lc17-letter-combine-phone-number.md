source: https://leetcode.com/problems/letter-combinations-of-a-phone-number/#/description

Given a digit string, return all possible letter combinations that the number could represent.

```
Input:Digit string "23"
Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
```
## Code
Permutation. Easy to use recursion or iteration.
time complexity: 3^n or 4^n.

```c#
public class Solution {
    public IList<string> LetterCombinations(string digits) {
        var maps = new string[] {"abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
        var result = new List<string>();
        if (digits == null || digits.Length == 0) return result;
        result.Add("");
        
        foreach(var d in digits) {
            var tempResult = new List<string>();
            foreach(var str in result) {
                foreach(var c in maps[d - '2']) {
                    tempResult.Add(str + c.ToString());
                }
            }
            result = tempResult;
        }
        
        return result;
    }
}
```
