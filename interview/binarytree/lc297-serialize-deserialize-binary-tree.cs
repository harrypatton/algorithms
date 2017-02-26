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
