source: https://leetcode.com/problems/add-and-search-word-data-structure-design/#/description

Design a data structure that supports the following two operations:

* `void addWord(word)`
* `bool search(word)`
* `search(word)` can search a literal word or a regular expression string containing only letters a-z or `.` which means it can represent any one letter.

For example:
```
addWord("bad")
addWord("dad")
addWord("mad")
search("pad") -> false
search("bad") -> true
search(".ad") -> true
search("b..") -> true
```

Note: You may assume that all words are consist of lowercase letters a-z.

```c#
public class WordDictionary {
    
    public class TrieNode {
        public bool isWord;
        public TrieNode[] nodes;
        public TrieNode() {
            isWord = false;
            nodes = new TrieNode[26];
        }
    }

    public TrieNode root;
    
    /** Initialize your data structure here. */
    public WordDictionary() {
        root = new TrieNode();
    }
    
    /** Adds a word into the data structure. */
    public void AddWord(string word) {
        if (word != null && word.Length != 0) {
            var node = root;
            foreach(var c in word) {
                var index = c - 'a';
                if (node.nodes[index] == null) node.nodes[index] = new TrieNode();
                node = node.nodes[index];
            }
            node.isWord = true;
        }
    }
    
    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word) {
        return Search(root, word);
    }
    
    public bool Search(TrieNode node, string word) {
        if (node != null && node.isWord && word.Length == 0) return true;
        
        for(int i = 0; i < word.Length; i++) {
            var c = word[i];
            if (c == '.') {
                // we're going to try every possible solution
                foreach(var n in node.nodes) {
                    if (n != null && Search(n, word.Substring(i + 1))) return true;
                }
                return false;
            } else {
                node = node.nodes[c - 'a'];
                if (node == null) return false;
            }
        }
        
        return node != null && node.isWord;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */

```
