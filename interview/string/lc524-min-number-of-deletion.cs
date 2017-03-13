public class Solution {
    public string FindLongestWord(string s, IList<string> d) {
        string result = string.Empty;
        
        // handle edge cases
        if (s == null || s.Length == 0 || d == null || d.Count == 0) {
            return result;
        }

        foreach(var str in d) {
            if (s.Length >= str.Length) {
                int p1 = 0;
                int p2 = 0;
                
                // compare two pointers
                while (p1 < s.Length && p2 < str.Length) {
                    if (s[p1++] == str[p2]) {
                        p2++;
                    }
                }
                
                // find a candidate
                if (p2 == str.Length) {
                    if (result == string.Empty || result.Length < str.Length || (result.Length == str.Length && string.Compare(str, result) < 0)) {
                        result = str;
                    }
                }
            }
        }
        
        return result;
    }
}
