.NET doesn't have any built-in support for that so I create one using link below,

* http://allanrbo.blogspot.com/2011/12/simple-heap-implementation-priority.html
* https://en.wikipedia.org/wiki/Binary_heap

You can also look at MinHeap implementation from merge-k-sorted-list here https://github.com/harrypatton/algorithms/blob/master/interview/whiteboard/lc23-merge-k-sorted-list.md

```csharp
class MinHeap<T> where T: IComparable<T> {
        private List<T> data = new List<T>();

        public T Peek() {
            if (data.Count > 0) {
                return data[0];
            } else {
                throw new ArgumentException("Empty collection.");
            }            
        }

        public void Add(T t) {
            data.Add(t);
            int i = data.Count - 1;

            while(i > 0) {
                // parent index
                int j = (i + 1) / 2 - 1;
                T parent = data[j];

                if(parent.CompareTo(t) <= 0) {
                    break; // good because parent is smaller.
                } else {
                    // swap the node
                    data[j] = t;
                    data[i] = parent;

                    i = j;
                }
            }
        }

        public T ExtractMin() {
            if (data.Count < 0) {
                throw new ArgumentException();
            }

            var result = data[0];
            data[0] = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);

            this.Heapify(0);

            return result;
        }

        public void Heapify(int i) {
            int smallest = i;
            int left = 2 * (i + 1) - 1;
            int right = 2 * (i + 1);
            
            // From wiki: Swap with its smaller child in a min-heap and its larger child in a max-heap.
            
            if (left < data.Count && (data[left].CompareTo(data[smallest]) < 0)) {
                smallest = left;
            } 
            
            if (right < data.Count && (data[right].CompareTo(data[smallest]) < 0)) {
                smallest = right;
            }

            if (smallest != i) {
                var temp = data[i];
                data[i] = data[smallest];
                data[smallest] = temp;
                this.Heapify(smallest);
            }
        }
    }

    public class MyType<T> : IComparable<T> {
        public int CompareTo(T other) {
            return 0;
        }
    }
```
