public class Solution_Recursion {
    public IList<IList<int>> Subsets(int[] nums) {
        if (nums == null) {
            return new List<IList<int>>();
        }
        
        return Subsets(nums, 0);
    }
    
    public IList<IList<int>> Subsets(int[] nums, int start) {
        var result = new List<IList<int>>();
        
        if (start >= nums.Length) {
            result.Add(new List<int>());
        }
        
        if (start <= nums.Length - 1) {
            var subResult = Subsets(nums, start + 1);            
            result.AddRange(subResult);
            
            foreach(var list in subResult) {
                var newList = new List<int>(list);
                newList.Insert(0, nums[start]);
                result.Add(newList);
            }
        }
        
        return result;
    }
}

public class Solution_Bitmap {
        public IList<IList<int>> Subsets(int[] nums) {
            if (nums == null) {
                return new List<IList<int>>();
            }

            // init the result
            var result = new IList<int>[(int)(Math.Pow(2, nums.Length))];
            for (int i = 0; i < result.Length; i++) {
                result[i] = new List<int>();

                for (int j = 0; j < nums.Length; j++) {
                    if (((i >> j) & 1) == 1) {
                        result[i].Add(nums[j]);
                    }
                }
            }

            return result;
        }
    }
