    public class Solution {
        public int FindKthLargest(int[] nums, int k) {
            var heap = new Heap();

            for (int i = 0; i < nums.Length; i++) {
                if (i < k) {
                    heap.Add(nums[i]);
                }
                else if (nums[i] > heap.Min) {
                    heap.Pop();
                    heap.Add(nums[i]);
                }
            }

            return heap.Min;
        }
    }

    public class Heap {
        private SortedSet<int> set;
        private Dictionary<int, int> counter;

        public Heap() {
            set = new SortedSet<int>();
            counter = new Dictionary<int, int>();
        }

        public void Add(int value) {
            if (!counter.ContainsKey(value)) {
                set.Add(value);
                counter[value] = 1;                
            }
            else {
                counter[value]++;
            }
        }

        public void Pop() {
            int value = set.Min;
            counter[value]--;

            if (counter[value] == 0) {
                set.Remove(value);
            }
        }

        public int Min {
            get {
                return set.Min;
            }
        }
    }
