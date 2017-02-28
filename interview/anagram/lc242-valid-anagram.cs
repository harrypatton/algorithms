public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s == null || t == null) {
            return false;
        }
        
        if (s.Length != t.Length) {
            return false;
        }
        
        bool result = true;
        var counter = new int[26];
        
        foreach(char c in s) {
            counter[c - 'a']++;
        }
        
        foreach(char c in t) {
            counter[c - 'a']--;
            if (counter[c -'a'] < 0) {
                result = false;
                break;
            }
        }
        
        return result;
    }
}
