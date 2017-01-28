public class Solution {
    public int FindRadius(int[] houses, int[] heaters) {
        Array.Sort(houses);
        Array.Sort(heaters);
        
        int result = 0;
        
        foreach(var house in houses) {
            int minRadius = 0;            
            int index = Array.BinarySearch(heaters, house);
            
            // if find, it returns 0
            // otherwise it returns a negative of the complement of next 
            // larger element (or length when there is no larger element)
            if (index < 0) {
                index = ~index;
                
                if (index == heaters.Length) {
                    minRadius = house - heaters[heaters.Length - 1];
                } else if (index == 0) {
                    minRadius = heaters[0] - house;
                } else {
                    minRadius = Math.Min(heaters[index] - house, house - heaters[index - 1]);
                }
            }
            
            result = Math.Max(result, minRadius);
        }
        
        return result;
    }
}
