public class Solution_NextPermutation {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        var result = new List<IList<int>>();
        
        if (nums == null || !nums.Any()) {
            return result;
        }
        
        Array.Sort(nums);
        result.Add(new List<int>(nums));
        
        while(true) {
            // find next permutation
            
            // backward: find the first element which is less than its next element.
            int index = nums.Length - 1;
            for(int i = nums.Length - 2; i >= 0; i--) {
                if (nums[i] < nums[i+1]) {
                    index = i;
                    break;
                }
            }
            
            // reach to the last permutation, quit.
            if (index == nums.Length - 1) {
                break;
            }
            
            // starting from i, find the last element which value is greater than nums[i].
            int indexSwap = index + 1;
            for(int i = indexSwap; i < nums.Length; i++) {
                if (nums[i] > nums[index]) {
                    indexSwap = i;
                }
            }
            
            // swap index and indexSwap
            // TODO: we could use Swap method here.
            var temp = nums[index];
            nums[index] = nums[indexSwap];
            nums[indexSwap] = temp;
            
            // reverse the order after index.
            // TODO: we could use built-in method.
            // Array.Reverse(nums, index + 1, nums.Length - 1 - index);
            for(int i = 0; i < (nums.Length -1 - index) / 2; i++) {
                var tempvalue = nums[index + 1 + i];
                nums[index + 1 + i] = nums[nums.Length - 1 - i];
                nums[nums.Length - 1 - i] = tempvalue;
            }
            
            result.Add(new List<int>(nums));
        }
        
        return result;
    }
}
