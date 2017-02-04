public class Solution {
    public int FourSumCount(int[] A, int[] B, int[] C, int[] D) {
        var dict1 = GetPairs(A, B);
        var dict2 = GetPairs(C, D);
        
        int count = 0;
        
        foreach(var k1 in dict1.Keys) {
            if (dict2.ContainsKey(-k1)) {
                count += dict1[k1] * dict2[-k1];
            }
        }
        
        return count;
    }
    
    private IDictionary<int, int> GetPairs(int[] a, int[] b) {
        var result = new Dictionary<int, int>();
        
        if (a != null && b != null && a.Any() && b.Any()) {
            for(int i = 0; i < a.Length; i++) {
                for (int j = 0; j < b.Length; j++) {
                    int sum = a[i] + b[j];                    
                    result[sum] = result.ContainsKey(sum) ? result[sum] + 1 : 1;
                }
            }
        }
        
        return result;
    }
}
