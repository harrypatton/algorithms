#Total Hamming Distance
source: https://leetcode.com/problems/total-hamming-distance/

The [Hamming distance](https://en.wikipedia.org/wiki/Hamming_distance) between two integers is the number of positions at which the corresponding bits are different.

Now your job is to find the total Hamming distance between all pairs of the given numbers.

Example
```
Input: 4, 14, 2
Output: 6

Explanation: In binary representation, the 4 is 0100, 14 is 1110, and 2 is 0010 (just
showing the four bits relevant in this case). So the answer will be:
HammingDistance(4, 14) + HammingDistance(4, 2) + HammingDistance(14, 2) = 2 + 2 + 2 = 6.
```

#Idea
Given two integers, to calculate the hamming distance, we can do XOR and then calculate how many "1" in that value.

e.g., 4(0100) ^ 14(1110) = 1010

For the value 1010, keep binary shift to left and check if 1 remaining.

time complexity: O(m * n^2). ``m`` is the bit-represented length of largest number. ``n`` is number count.

For the question itself, we can get all pairs and calculate hamming distance for each pair and get the sum.

**note**: unfortunately this solution gets a time-out. We need a more efficient way to do the work.

```
public class Solution {
    public int TotalHammingDistance(int[] nums) {
        if (nums == null || nums.Length < 2) {
            return 0;
        }
        
        int sum = 0;
        var cache = new Dictionary<int, int>();
        
        for(int i = 0; i < nums.Length; i ++) {
            for(int j = i + 1; j < nums.Length; j ++) {
                sum += GetHammingDistance(cache, nums[i], nums[j]);
            }
        }
        
        return sum;
    }
    
    public int GetHammingDistance(Dictionary<int, int> cache, int num1, int num2) {
        int xorValue = num1 ^ num2;
        int cacheKey = xorValue;
        int distance = 0;
        
        if (cache.ContainsKey(cacheKey)) {
            return cache[cacheKey];
        }
        
        // TODO: we can save a cache for hammingDistaince <=> xorValue
        
        while(xorValue > 0) {
            if ((xorValue & 1) == 1) {
                distance ++;
            }
            
            xorValue = xorValue >> 1;
        }
        
        cache[cacheKey] = distance;
        
        return distance;
    }
}
```

##Creative Solution
After checking Leetcode discussion, here's an interesting solution,
An 32-bit integer has 32 bits. 
* Assume one bit is 1 and others are 0. 
* Use this integer to AND all elements in the array. 
* If there're n elements in the array of which k elements equal to the value, the k elements have 1 in that position and (n-k) elements don't. The hamming distance for that position is k(n-k). 
* Continue to calculate for other positions of 1.

time complexity: O(32*n) = O(n).

#Learning
1. Just think of the problem from a different angle - bit by bit.
