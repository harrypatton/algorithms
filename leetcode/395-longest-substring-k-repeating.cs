public class Solution {
    public int LongestSubstring(string s, int k) {
        if (s == null || s.Length < k || k <= 0) {
          return 0;
        }
		
        // get count for every char
        var charCount = new Dictionary<char, int>();
        foreach(var c in s) {
          charCount[c] = charCount.ContainsKey(c) ? charCount[c] + 1 : 1;
        }

        // find out char which repeating count is less than k
        var excludedChars = new HashSet<char>();
        foreach(var c in charCount.Keys) {
          if (charCount[c] < k) {
            excludedChars.Add(c);
          }
        }

        // find the string meet the requirement
        if (excludedChars.Count == 0) {
          return s.Length;
        }

        int max = 0;		
        var substrings = s.Split(excludedChars.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        foreach(var substr in substrings){
          max = Math.Max(max, LongestSubstring(substr, k));
        }

        return max;
    }
}
