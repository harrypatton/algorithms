source: https://leetcode.com/problems/longest-absolute-file-path/#/solutions

Check the source for problem.

## Clean Solution
It uses stack to track parent and level. It also calculates max length on the fly.

``` C#
public class Solution {
    public int LengthLongestPath(string input) {
    	if(input == null || input.Length == 0) return 0;
        int max = 0;
        var stack = new Stack<int>();
        stack.Push(0); // dummy parent.

        // iterate each one
        foreach(var str in input.Split('\n')) {        	
        	// the first level directory without '\t' is 0.
        	var level = str.LastIndexOf('\t') + 1; 

        	while(stack.Count - 1 > level) stack.Pop(); // move parent to the top of stack
        	var length = stack.Peek() + (str.Length - level) + 1; // parent + current length + separator
        	stack.Push(length);
        	if (str.Contains('.')) max = Math.Max(max, length - 1); // -1 means remove the separator
        }

        return max;
    }
}
```

## Original Solution
1. I know the string is DFS-serialized one but failed to write out an iteration solution to deserialize it using stack. I should have
used the `\t` count to induce the level. What I implemented below is using recursion.
2. My solution is using recursion to create a tree and then one-time iteration to get max length. The discussion solution actually
get max length on the fly.
3. I am confused that `\t` is a char and `@"\t"` is actually size-2 string in C# language. 

```c#
public class Solution {
	public class TreeNode {
		public int val;
		public List<TreeNode> nodes;
		public bool isFile;
		public TreeNode(int value) {
			val = value;
			nodes = new List<TreeNode>();
			isFile = false;
		}
	}

	public int max = 0;

    public int LengthLongestPath(string input) {
    	if (input == null || input.Length == 0) return 0;
        var strs = input.Split(new string[] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
        var root = new TreeNode(0);
        CreateNode(root, strs);
        GetMaxLength(-2, root);
        return max;
    }

    public void GetMaxLength(int parentPath, TreeNode node) {
    	if (node == null) return;
    	int currentPath = parentPath + 1 + node.val;
    	if (node.isFile) max = Math.Max(max, currentPath);

    	foreach(var child in node.nodes) {
    		GetMaxLength(currentPath, child);
    	}
    }

    public void CreateNode(TreeNode parent, string[] nodeStrs) {
    	if (nodeStrs.Length == 0) {
    		return;    		
    	}

    	var subNodeStrs = new List<string>();
    	TreeNode child = null;

    	for(int i = 0; i < nodeStrs.Length; i++) {
    		var str = nodeStrs[i];
    		if (!str.StartsWith("\t") && i != 0) {
    			CreateNode(child, subNodeStrs.ToArray());    			
    			subNodeStrs = new List<string>();
    		}

    		if (str.StartsWith("\t")) {
    			subNodeStrs.Add(str.Substring(1));
    		} else {
    			child = new TreeNode(str.Length);
    			child.isFile = str.Contains('.');
    			parent.nodes.Add(child);
    		}
    	}

    	if (subNodeStrs.Count > 0) {
    		CreateNode(child, subNodeStrs.ToArray());   
    	}
    }
}
```
