public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s == null || s.Length == 0) {
            return 0;
        }
        
        int start = 0;
        int end = 0;
        int max = 0;
        int counter = 0;
        var hashset = new HashSet<char>();
        
        while (end < s.Length) {
            // reach a duplicate
            if (hashset.Contains(s[end])) {
                while(s[start] != s[end]) {
                    counter--;
                    hashset.Remove(s[start]);
                    start++;
                }               
                start++;                                
            } else { // see new char, update the result.
                hashset.Add(s[end]);
                counter++;
                max = Math.Max(max, counter);
            }
            
            end++;
        }
        
        return max;
    }
}
