# LC416. Partition Equal Subset Sum
[source](https://leetcode.com/problems/partition-equal-subset-sum/#/description). Given a non-empty array containing only positive integers, find if the array can be partitioned into two subsets such that the sum of elements in both subsets is equal.

## Analysis
1. The problem actually asks if any subset which sum is equal to total_sum/2. The subset must be smaller than current array.
2. DP solution, O(i * total_sum / 2)
3. Edge cases
	* if total sum is odd number, it should be false.
	* We can use O(1+total_sum/2) space.
	* Base `result[0] == true`. It is convenient when current element is equal to target sum.
	* When scan from `total_sum / 2` to 0, please check if `current_sum - current element >= 0` to avoid invalid index.
	* I merge first number into the same loop. In the first version, I set it separately but when handle the final result, I forget that case.

```csharp
public class Solution {
    public bool CanPartition(int[] nums) {
        if (nums == null || nums.Length < 2) {
            return false;
        }
        
        int sum = 0;
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
        }
        
        if (sum % 2 == 1) return false;
        
        var result = new bool[sum/2 + 1];
        result[0] = true;
        
        for(int i = 0; i < nums.Length - 1; i++) {
            for (int j = sum /2; j >=0; j--) {
                result[j] = result[j] || (j >= nums[i] ? result[j - nums[i]] : false);
                if (j == sum /2 && result[j]) {
                    return true;
                }
            }
        }
        
        return false;
    }
}
```
