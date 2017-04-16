Source: https://leetcode.com/problems/data-stream-as-disjoint-intervals/#/description

Given a data stream input of non-negative integers a1, a2, ..., an, ..., 
summarize the numbers seen so far as a list of disjoint intervals.

For example, suppose the integers from the data stream are 1, 3, 7, 2, 6, ..., then the summary will be:

```
[1, 1]
[1, 1], [3, 3]
[1, 1], [3, 3], [7, 7]
[1, 3], [7, 7]
[1, 3], [6, 7]
```

This problem doesn't have a C# OJ, but I look at the Java one.

Java has an interesting class TreeMap which is the same as SortedDictionary; however, the class can return a LowerKey and HigherKey for a given key.
In C#, if we want to get the same functionatites, we have to use binary search to get the result.

Here's the solution from discussion page. 

```java
public class SummaryRanges {
    TreeMap<Integer, Interval> tree;

    public SummaryRanges() {
        tree = new TreeMap<>();
    }

    public void addNum(int val) {
        if(tree.containsKey(val)) return;
        Integer l = tree.lowerKey(val);
        Integer h = tree.higherKey(val);
        
        // when the point can join lower and higher ones.
        if(l != null && h != null && tree.get(l).end + 1 == val && h == val + 1) {
            tree.get(l).end = tree.get(h).end;
            tree.remove(h);
        } else if(l != null && tree.get(l).end + 1 >= val) { // when the point belongs to lower interval or extend a little bit
            tree.get(l).end = Math.max(tree.get(l).end, val);
        } else if(h != null && h == val + 1) { // when the point can extend higher interval a little bit
            tree.put(val, new Interval(val, tree.get(h).end));
            tree.remove(h);
        } else { // when it should be a separate interval
            tree.put(val, new Interval(val, val));
        }
    }

    public List<Interval> getIntervals() {
        return new ArrayList<>(tree.values());
    }
}
```
