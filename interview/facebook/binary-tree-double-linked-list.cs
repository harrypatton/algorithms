public class TreeNode {
    public int Value { get; set; }

    public TreeNode Left { get; set; }

    public TreeNode Right { get; set; }

    public TreeNode(int value, TreeNode left, TreeNode right) {
        this.Value = value;
        this.Left = left;
        this.Right = right;
    }
}

public class Solution {
    public TreeNode GetDoubleLinked(TreeNode root) {
        TreeNode head, tail;
        GetDoubleLinked(root, out head, out tail);
        return head;
    }

    public void GetDoubleLinked(TreeNode root, out TreeNode head, out TreeNode tail) {
        TreeNode head1 = null;
        TreeNode tail1 = null;

        if (root.Left != null) {
            GetDoubleLinked(root.Left, out head1, out tail1);
            tail1.Right = root;
            root.Left = tail1;
        }

        TreeNode head2 = null;
        TreeNode tail2 = null;
        if (root.Right != null) {
            GetDoubleLinked(root.Right, out head2, out tail2);
            root.Right = head2;
            head2.Left = root;
        }

        // update head and tail
        head = head1 ?? root;
        tail = tail2 ?? root;

        head.Left = tail;
        tail.Right = head;
    }

    public void PrintTreeInOrder(TreeNode root) {
        if (root.Left != null) {
            PrintTreeInOrder(root.Left);
        }

        Console.Write(root.Value + ", ");

        if (root.Right != null) {
            PrintTreeInOrder(root.Right);
        }
    }

    public void PrintLinkedListForward(TreeNode header) {
        var temp = header.Right;
        Console.Write(header.Value + ", ");

        while(temp != header) {
            Console.Write(temp.Value + ", ");
            temp = temp.Right;
        }

        Console.WriteLine();
    }

    public void PrintLinkedListBackward(TreeNode header) {
        var temp = header.Left.Left;
        Console.Write(header.Left.Value + ", ");

        while (temp != header.Left) {
            Console.Write(temp.Value + ", ");
            temp = temp.Left;
        }

        Console.WriteLine();
    }
}
