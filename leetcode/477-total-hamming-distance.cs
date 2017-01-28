public class Solution {
    public int TotalHammingDistance(int[] nums) {
        if (nums == null || nums.Length < 2) {
            return 0;
        }
        
        int distance = 0;
        int value = 1;
        
        while (value > 0) {
            
            int countWithPositionSet = 0;
            
            foreach(var num in nums) {
                if ((num & value) == value) {
                    countWithPositionSet++;
                }
            }
            
            distance += countWithPositionSet * (nums.Length - countWithPositionSet);
            
            value = value << 1;
        }
        
        return distance;
    }
}
