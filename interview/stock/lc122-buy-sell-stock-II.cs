public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices == null || prices.Length < 2) {
            return 0;
        }
        
        int profit = 0;
        for(int i = 1; i < prices.Length; i++) {
            int diff = prices[i] - prices[i-1];
            profit += diff > 0 ? diff : 0;
        }
        
        return profit;
    }
}
