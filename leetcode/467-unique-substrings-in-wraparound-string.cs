public class Solution {
    public int FindSubstringInWraproundString(string p) {
        if (p == null || p.Length == 0) {
            return 0;
        }
        
        if (p.Length == 1) {
            return 1;
        }
        
        int[] letterMaxCountList = new int[26];
        int currentMaxCount = 0;
        
        for(int i = 0; i < p.Length; i++) {
            if (i > 0 && (p[i] == p[i - 1] + 1 || (p[i] == 'a' && p[i-1] == 'z'))) {
                currentMaxCount++;
            } else {
                currentMaxCount = 1;
            };
            
            // Update the count for every letter
            int index = p[i] - 'a';
            letterMaxCountList[index] = Math.Max(currentMaxCount, letterMaxCountList[index]);            
        }
            
        int result = 0;
        foreach(int count in letterMaxCountList) {
            result += count;
        }
        
        return result;
    }
}
