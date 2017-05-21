source: https://leetcode.com/problems/moving-average-from-data-stream/#/description

Given a stream of integers and a window size, calculate the moving average of all integers in the sliding window.

For example,
```
MovingAverage m = new MovingAverage(3);
m.next(1) = 1
m.next(10) = (1 + 10) / 2
m.next(3) = (1 + 10 + 3) / 3
m.next(5) = (10 + 3 + 5) / 3
```

## Analysis
* use a Queue to maintain in window element. When it is full, move the first one.
* keep a variable to track the sum.
* the algorithm can be O(1).

```c#
public class MovingAverage {
	private double sum;
	private Queue<int> q;
	private int size;

    /** Initialize your data structure here. */
    public MovingAverage(int size) {
        this.size = size;
        sum = 0;
        q = new Queue<int>();
    }
    
    public double Next(int val) {
    	sum += val;
    	q.Enqueue(val);

        if (q.Count > size) sum -= q.Dequeue();

        return sum / q.Count;
    }
}
```
