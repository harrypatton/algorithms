public class Solution {
    public void FlattenLinkedList(TreeLinkedNode node) {
        if (node == null) {
            return;
        }

        TreeLinkedNode currentNode = new TreeLinkedNode(0, null, null);
        var queue = new Queue<TreeLinkedNode>();
        queue.Enqueue(node);

        while(queue.Count != 0) {
            var tempNode = queue.Dequeue();
            currentNode.Next = tempNode;
            
            while(currentNode.Next != null) {
                if (currentNode.Next.Child != null) {
                    queue.Enqueue(currentNode.Next.Child);
                    currentNode.Next.Child = null;
                }
                currentNode = currentNode.Next;
            }
        }

        currentNode.Next = null;
    }
}

public class TreeLinkedNode {
    public TreeLinkedNode Next { get; set; }
    public TreeLinkedNode Child { get; set; }
    public int Value { get; set; }

    public TreeLinkedNode(int value, TreeLinkedNode next, TreeLinkedNode child) {
        this.Value = value;
        this.Next = next;
        this.Child = child;
    }
}
