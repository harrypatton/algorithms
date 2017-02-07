public class Solution {
    public int ArrangeCoins(int n) {
        double sqrtValue = Math.Sqrt(2) * Math.Sqrt(n);
        int upperBound = (int)Math.Floor(sqrtValue);
        int lowerBound = (int)Math.Ceiling(sqrtValue - 2);
        int sum = (lowerBound % 2 == 0) ? (lowerBound / 2 * (lowerBound + 1)) : ((lowerBound + 1) / 2 * lowerBound);
        
        for(int i = lowerBound + 1; i <= upperBound; i++) {
            sum += i;
            
            // overflow so we find the result
            if (sum < 0 || sum > n) {
                return i - 1;
            }
        }
        
        // be careful about this edge cases. In this case, upperBound is the final result.
        return upperBound;
    }
}
