public class Solution {
    public string LongestPalindrome(string s) {
        if (s == null || s.Length == 0) {
            return s;
        }
        
        var result = "";
        for(int i = 0; i < s.Length; i++) {
            result = GetLongest(s, result, i - 1, i +1);
            result = GetLongest(s, result, i, i +1);
        }
        
        return result;        
    }
    
    public string GetLongest(string s, string result, int start, int end) {
        while (start >= 0 && end < s.Length && s[start] == s[end]) {
            start--;
            end++;
        }
        
        if (end - start - 1 > result.Length) {
            result = s.Substring(start+1, end - start - 1);
        }
        
        return result;
    }
}
