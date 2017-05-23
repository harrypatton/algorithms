source: https://leetcode.com/problems/unique-word-abbreviation/#/description

An abbreviation of a word follows the form <first letter><number><last letter>.

Assume you have a dictionary and given a word, find whether its abbreviation is unique in the dictionary. 
A word's abbreviation is unique if no other word from the dictionary has the same abbreviation.

Note: if the dictionary has only one word "Hello", the method isUnique("Hello") should return true.

## Analysis
Hashtable works fine.

```c#
public class ValidWordAbbr {
    
    public class AB {
        public string str;
        public bool isUnique;
        public AB(string str) {
            this.str = str;
            this.isUnique = true;
        }
    }
    
    private Dictionary<string, AB> mapping;
    public ValidWordAbbr(string[] dictionary) {
        mapping = new Dictionary<string, AB>();
        foreach(var w in dictionary) {
            var ab = GetAB(w);
            if (mapping.ContainsKey(ab)) {
                if (mapping[ab].str != w) mapping[ab].isUnique = false;
            } else mapping[ab] = new AB(w);
        }
    }
    
    public bool IsUnique(string word) {
        var ab = GetAB(word);
        return !mapping.ContainsKey(ab)
            || (mapping[ab].isUnique && mapping[ab].str == word);
    }
    
    private string GetAB(string word) {
        if (word.Length <= 2) return word;
        else return word[0] + (word.Length - 2).ToString() + word[word.Length - 1];
    }
}
```
