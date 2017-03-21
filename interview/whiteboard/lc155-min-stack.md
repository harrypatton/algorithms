# LC155. Min Stack
source: https://leetcode.com/problems/min-stack/#/description

Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

```
push(x) -- Push element x onto stack.
pop() -- Removes the element on top of the stack.
top() -- Get the top element.
getMin() -- Retrieve the minimum element in the stack.
```

# Analysis
1. It is funny that I didn't come up with a good answer in first time. I always think about sorted array to make getMin() in constant time; but sorting needs O(logn). I didn't realize I can push min value at every stages into the stack or in a separate list. What a shame!

```csharp
public class MinStack {
    private Stack<int> stack;
    private int min = int.MaxValue;

    /** initialize your data structure here. */
    public MinStack() {
        stack = new Stack<int>();
    }
    
    public void Push(int x) {
        stack.Push(min);
        stack.Push(x);
        min = Math.Min(min, x);
    }
    
    public void Pop() {
        stack.Pop();
        min = stack.Pop();
    }
    
    public int Top() {
        return stack.Peek();
    }
    
    public int GetMin() {
        return min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
```
