public class Solution {
    public int FindTargetSumWays(int[] nums, int S) {
      // check arguments
      if (nums == null || !nums.Any()) {
        return 0;
      }
      
      int sum = 0;
      foreach(var num in nums) {
        sum += num;
      }
      
      if (sum < S || (sum - S) % 2 == 1) {
        return 0;
      }
      
      int target = (sum - S) / 2;
            
      var sumList = new int[target+1];
      sumList[0] = 1;
      
      foreach(var num in nums) {
        for(int i = target; i >= num; i--) {
          sumList[i] += sumList[i - num];          
        }
      }
      
      return sumList[target];
    }
}

public class SolutionDP1 {
    public int FindTargetSumWays(int[] nums, int S) {
      // check arguments
      if (nums == null || !nums.Any()) {
        return 0;
      }

      // initalize with the first element
      IDictionary<int, int> sumMap = new Dictionary<int, int>();
      
      if (nums[0] == 0) {
          sumMap.Add(0, 2); // two ways to get 0. 
      } else {
        sumMap.Add(nums[0], 1);
        sumMap.Add(-nums[0], 1);
      }
      
      for(int i = 1; i < nums.Length; i ++) {
        // a new sum map because of the new element
        var newSumMap = new Dictionary<int, int>();
        
        foreach(int sum in sumMap.Keys) {
          foreach(int newSum in new int[] {sum + nums[i], sum - nums[i]}) {
            if (newSumMap.ContainsKey(newSum)) {
              newSumMap[newSum] += sumMap[sum];
            } else {
              newSumMap[newSum] = sumMap[sum];
            }
          }
        }
        
        sumMap = newSumMap;
      }
      
      return sumMap.ContainsKey(S) ? sumMap[S] : 0;      
    }
}
