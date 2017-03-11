public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices == null || prices.Length < 2) {
            return 0;
        }
        
        int min = prices[0];
        int maxProfit = 0;
        
        for(int i = 1; i< prices.Length; i++) {
            maxProfit = Math.Max(maxProfit, prices[i] - min);
            min = Math.Min(min, prices[i]);
        }
        
        return maxProfit;
    }
}
