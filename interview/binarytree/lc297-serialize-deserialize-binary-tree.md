Source: https://leetcode.com/problems/serialize-and-deserialize-binary-tree/#/description

Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.

Design an algorithm to serialize and deserialize a binary tree. There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.
    
## Code using BFS
```c#
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

/*
Solution - BFS
    Serialization
        1. use BFS to traverse each layer. root goes to the queue.
        2. take one from queue. 
            a. if node is not null, add the value to result and then add left/right to queue.
            b. if not is null, add empty string to result.
        3. print out the result by string.Join with comma.
    Deserialization
        1. parse the array.
        2. if array is empty, it is an empty tree.
        3. Create root node first and add to queue.
        3. Iteration - start from index 1.
            a. two steps at a time to handle left and right. if one is not null, add the queue.
            b. Go to the queue to get current parent node.

*/
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        var result = new List<string>();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while(q.Count > 0) {
            var node = q.Dequeue();
            if (node == null) result.Add("");
            else {
                result.Add(node.val.ToString());
                q.Enqueue(node.left);
                q.Enqueue(node.right);
            }
        }
        
        return string.Join(",", result);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        // NOTE here. If data is string, the elements will contain only one element which is empty value.
        var elements = data.Split(',');
        
        var q = new Queue<TreeNode>();
        var root = GetNodeAndEnqueueIfNotNull(elements[0], q);
        
        for(int i = 1; i < elements.Length; i = i + 2) {
            var p = q.Dequeue();
            p.left = GetNodeAndEnqueueIfNotNull(elements[i], q);
            p.right = GetNodeAndEnqueueIfNotNull(elements[i+1], q);
        }
        
        return root;
    }
    
    private TreeNode GetNodeAndEnqueueIfNotNull(string str, Queue<TreeNode> q) {
        var node = str == "" ? null : new TreeNode(Convert.ToInt32(str));
        if (node!= null) q.Enqueue(node);
        return node;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));
```

## Code with preorder
```c#
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        var list = new List<string>();
        serialize(list, root);
        
        return string.Join(",", list);
    }
    
    public void serialize(IList<string> list, TreeNode root) {
        if (root == null) {
            list.Add(string.Empty);
        } else {
            list.Add(root.val.ToString());
            serialize(list, root.left);
            serialize(list, root.right);
        }
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if (data == null) {
            data = string.Empty;
        }
        
        var elements = data.Split(',');
        int startIndex = 0;
        return deserialize(elements, ref startIndex);
    }
    
    public TreeNode deserialize(string[] elements, ref int startIndex) {
        if(elements[startIndex] == string.Empty) {
            startIndex++;
            return null;
        } else {
            var node = new TreeNode(Convert.ToInt32(elements[startIndex]));
            startIndex++;
            node.left = deserialize(elements, ref startIndex);
            node.right = deserialize(elements, ref startIndex);
            
            return node;
        }
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec_Preorder_Parenthesis {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if (root == null) {
            return string.Empty;
        }
        
        string result = root.val.ToString();
        if (root.left == null && root.right == null) {
            return result;
        } else {
            result = string.Format("{0}({1})({2})", result, serialize(root.left), serialize(root.right));
        }
        
        return result;
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if (string.IsNullOrEmpty(data)) {
            return null;
        }
        
        // find value
        var subTreeOpenBracket = data.IndexOf("(");
        int value = 0;
        
        if (subTreeOpenBracket < 0) {
            value = Convert.ToInt32(data);
            return new TreeNode(value);
        }
        
        value = Convert.ToInt32(data.Substring(0, subTreeOpenBracket));
        var node = new TreeNode(value);
        
        // find left
        int subTreeCloseBracket = FindCloseBracket(data, subTreeOpenBracket + 1);
        node.left = deserialize(data.Substring(subTreeOpenBracket + 1, subTreeCloseBracket - subTreeOpenBracket - 1));
        
        // find right
        subTreeOpenBracket = subTreeCloseBracket + 1;
        subTreeCloseBracket = FindCloseBracket(data, subTreeOpenBracket + 1);
        node.right = deserialize(data.Substring(subTreeOpenBracket + 1, subTreeCloseBracket - subTreeOpenBracket - 1));
        
        return node;
    }
    
    public int FindCloseBracket(string data, int startIndex) {
        int diff = 1;
        int i = 0;
        
        for(i = startIndex; i < data.Length; i++) {
            diff = data[i] == '(' ? diff + 1 : (data[i] == ')' ? diff - 1 : diff);
            if (diff == 0) {
                break;
            }
        }
        
        return i;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));

```
