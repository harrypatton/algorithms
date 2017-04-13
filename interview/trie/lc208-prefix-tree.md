
# Using Dictionary
This code uses Dictionary to implement the trie. 

Space complexity

* `26 + 26^2 + 26^3 + 26^n` children. Each child is a char with dictionary. `n` is the longest word length. so total is `O(26^n)`. 
* If we use a word as hash key instead of trie structure, each word is `n chars`; we have `26^n` words (each position could be 26 choices) so total space is `n*26^n`.

Time complexity: O(n). the word length.

```csharp
public class TrieNode {
    
    private Dictionary<char, TrieNode> children;
    
    public TrieNode() {
        children = new Dictionary<char, TrieNode>();
    }
    
    public bool ContainsChar(char c) {
        return children.ContainsKey(c);
    }
    
    public TrieNode GetNode(char c) {
        return children[c];
    }
    
    public void AddChar(char c) {
        children[c] = new TrieNode();
    }        
}

public class Trie {

    private TrieNode root;
    
    /** Initialize your data structure here. */
    public Trie() {
        root = new TrieNode();
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {
        var currentNode = root;
        
        foreach(char c in word + "*") {
            if (!currentNode.ContainsChar(c)) {
                currentNode.AddChar(c);
            }
            
            currentNode = currentNode.GetNode(c);
        }
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        return StartsWith(word + "*");
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        var currentNode = root;
        
        foreach(char c in prefix) {
            if (!currentNode.ContainsChar(c)) {
                return false;
            }
            
            currentNode = currentNode.GetNode(c);
        }
        
        return true;
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
