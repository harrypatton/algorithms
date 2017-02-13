public class Solution {
    public int ThirdMax(int[] nums) {
        if (nums == null) {
            return 0;
        }
        
        int max = int.MinValue;
        int medium = int.MinValue;
        int min = int.MinValue;
        
        foreach(var num in nums) {
            if (num > max) {
                min = medium;
                medium = max;
                max = num;
            } else if (num > medium) {
                min = medium;
                medium = num;
            } else if (num > min) {
                min = num;
            }
        }
        
        int hasMinValue = false;
        foreach(var num in nums) {
            if (num == int.MinValue) {
                hasMinValue = true;
                break;
            }
        }
        
        if (min != int.MinValue) {
            return min;
        } else {
            if (!hasMinValue) {
                return max;
            } else {
                return medium == int.MinValue ? max : min;
            }
        }
    }
}
