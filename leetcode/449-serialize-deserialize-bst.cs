
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if (root == null) {
            return string.Empty;
        } else {
            string left = serialize(root.left);
            string right = serialize(root.right);
            return string.Format("{0}({1})({2})", root.val, left, right);
        }
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        // check invalid scenarios        
        if (data == null || data == string.Empty) {
            return null;
        }
        
        int openIndex = data.IndexOf('(');
        var root = new TreeNode(Convert.ToInt32(data.Substring(0, openIndex)));
        
        var endIndex = FindClose(data, openIndex);
        var leftTreeString = data.Substring(openIndex+1, endIndex - openIndex - 1);
        root.left = deserialize(leftTreeString);
        
        openIndex = endIndex+1;
        endIndex = FindClose(data, openIndex);
        var rightTreeString = data.Substring(openIndex+1, endIndex - openIndex - 1);
        root.right = deserialize(rightTreeString);
        
        return root;
    }
    
    private int FindClose(string data, int openIndex) {
        int counter = 1;
        
        for(int i = openIndex + 1; i < data.Length; i++) {
            if(data[i] == ')') {
                counter--;
            } else if(data[i] == '(') {
                counter++;
            }
            
            if (counter == 0) {
                return i;
            }
        }
        
        return -1;
    }
}
