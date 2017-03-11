public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices == null || prices.Length < 2) {
            return 0;
        }
        
        var prefix = CalculatePrefix(prices);
        var suffix = CalculateSuffix(prices);
        
        int max = 0;
        for(int i = 0; i < prices.Length; i++) {
            max = Math.Max(max, prefix[i] + suffix[i]);
        }
        
        return max;
    }
    
    private int[] CalculatePrefix(int[] prices) {
        var result = new int[prices.Length];
        
        // assume previous price is very high
        int min = int.MaxValue;
        int max_result = 0;
        
        for(int i = 0; i < prices.Length; i++) {
            result[i] = Math.Max(max_result, prices[i] - min);
            max_result = Math.Max(max_result, result[i]);
            min = Math.Min(min, prices[i]);
        }
        
        return result;
    }
    
    private int[] CalculateSuffix(int[] prices) {
        var result = new int[prices.Length];
        
        // assume next price is very low. Don't use int.MinValue because it may cause overflow later.
        int max = 0;
        int max_result = 0;
        
        for(int i = prices.Length - 1; i >= 0; i--) {
            result[i] = Math.Max(max_result, max - prices[i]);
            max_result = Math.Max(max_result, result[i]);
            max = Math.Max(max, prices[i]);
        }
        
        return result;
    }
}
