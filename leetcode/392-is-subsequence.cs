public class Solution {
    public bool IsSubsequence(string s, string t) {
        if (s == null || t == null) {
            return false;
        }
        
        int indexS = 0;
        int indexT = 0;
        
        while(indexS < s.Length && indexT < t.Length) {
            if (s[indexS] == t[indexT]) {
                indexS++;
            }
            
            indexT++;
        }
        
        return indexS == s.Length;
    }
}
