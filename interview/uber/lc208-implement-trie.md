source: https://leetcode.com/problems/implement-trie-prefix-tree/#/description

Implement a trie with insert, search, and startsWith methods.

Note: You may assume that `all inputs are consist of lowercase letters a-z.`

```c#
public class Trie {
    
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
    public Trie() {
        root = new TrieNode();
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {
        if(word != null && word != "") {
            TrieNode node = root;
            foreach(char c in word) {
                var index = c - 'a';
                if (node.nodes[index] == null) node.nodes[index] = new TrieNode();                    
                node = node.nodes[index];
            }
            node.isWord = true;
        }
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        if (word == null || word.Length == 0) return false;
        else {
            TrieNode node = FindNode(word);
            return node != null && node.isWord;
        }
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        var node = FindNode(prefix);
        return node != null;
    }
    
    public TrieNode FindNode(string word) {
        if (word == null || word.Length == 0) return null;
        TrieNode node = root;
        foreach(char c in word) {
            var index = c - 'a';
            if (node.nodes[index] == null) return null;
            node = node.nodes[index];
        }
        return node;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
```
