source: https://leetcode.com/problems/letter-combinations-of-a-phone-number/#/description

Given a digit string, return all possible letter combinations that the number could represent.

A mapping of digit to letters (just like on the telephone buttons) is given below.

![Phone](http://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Telephone-keypad2.svg/200px-Telephone-keypad2.svg.png)

```
Input:Digit string "23"
Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
```

```c#
/*
it is more like permutation problem.
*/
public class Solution {
    /*
    the solution below uses a linkedlist to improve the perf when remove previous results.
    */
    public IList<string> LetterCombinations(string digits) {                
        var result = new LinkedList<string>();        
        if (string.IsNullOrEmpty(digits)) return result.ToList<string>();

        var mapping = new string[] {"0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
        result.AddLast("");
        
        // iterate over input string
        for(int k = 0; k < digits.Length; k++) {
            int count = result.Count;
            var chars = mapping[digits[k] - '0'];
            
            // iterate over previous result
            while(result.First().Length == k) {
                var str = result.First();
                result.RemoveFirst();
                
                // iterate over each mapping letter
                foreach(var c in chars) result.AddLast(str + c.ToString());
            }
        }
        
        return result.ToList<string>();
    }
    
    /*
    the solution below uses a list. It has a performance hit when remove elements from it.
    */
    public IList<string> LetterCombinations_List(string digits) {                
        var result = new List<string>();        
        if (string.IsNullOrEmpty(digits)) return result;
        
        // start from digit 2.
        var mapping = new string[] {"abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
        result.Add("");
        
        // iterate over input string
        foreach(var digit in digits) {
            int count = result.Count;
            var chars = mapping[digit - '2'];
            
            // iterate over previous result
            for(int i = 0; i < count; i++) {
                // interate over each possible letters
                foreach(var c in chars) {
                    result.Add(result[i] + c.ToString());
                }
            }
            
            // remove previous results
            for(int i = 0; i < count; i++) {
                result.RemoveAt(0);
            }
        }
        
        return result;
    }
}
```
