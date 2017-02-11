public class Solution
    {
        public int FindMaximumXOR(int[] nums)
        {
            if (nums == null || nums.Length < 2)
            {
                return 0;
            }

            int max = 0;
            int mask = 0;

            for (int i = 31; i >= 0; i--)
            {
                // get the mask like 100..00, 110..00, 111..00
                mask = mask | (1 << i);

                // in current iteration, we just care about the left part ending on position i.
                // e.g., the first iteration, we need to check most significant digit only

                var set = new HashSet<int>();
                foreach (var num in nums)
                {
                    set.Add(mask & num);
                }

                // Assume previous max is 101, the next one we hope is 1011; otherwise it goes to 1010.
                max = max << 1;
                int expectedMax = (max + 1) << i; // adding zeros in the end.

                // Try to find if two elements can get the expectedMax.
                // The tricky part is, if A^B == C, then A^C == B and B^C == A.
                foreach (var num in set)
                {
                    var searchNumber = num ^ expectedMax;
                    if (set.Contains(searchNumber))
                    {
                        max = max + 1;
                        break;
                    }
                }
            }

            return max;
        }
    }
