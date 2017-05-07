source: https://leetcode.com/problems/serialize-and-deserialize-binary-tree/#/description

## BFS
It is similar to what leetcode saves the BS tree.

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

	/*
	I decide to use BFS way to serialize. 
	When node is empty, just write ",". 
	*/
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        var result = new StringBuilder();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);

        while(q.Count > 0) {
        	var node = q.Dequeue();
        	if (node == null) result.Append(",");
        	else {
        		result.Append(node.val.ToString() + ",");
        		q.Enqueue(node.left);
        		q.Enqueue(node.right);
        	}
        }

        if(result.Length > 0 && result[result.Length - 1] == ',') result.Length--;

        return result.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if (data == null) return null;

        var values = data.Split(',');
        if(values[0] == "") return null;
        var root = new TreeNode(Convert.ToInt32(values[0]));
        var q = new Queue<TreeNode>();
        q.Enqueue(root);

        for(int i = 1; i < values.Length; i+=2) {
        	var node = q.Dequeue();
        	if (values[i] == "") node.left = null;
        	else {
        		node.left = new TreeNode(Convert.ToInt32(values[i]));
        		q.Enqueue(node.left);
        	}

        	if (values[i+1] == "") node.right = null;
        	else {
        		node.right = new TreeNode(Convert.ToInt32(values[i+1]));
        		q.Enqueue(node.right);
        	}
        }

        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));
```
