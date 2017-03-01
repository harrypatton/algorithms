public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        var result = new List<int>();
        
        if (s == null || p == null || s.Length < p.Length) {
            return result;
        }
        
        int counter = p.Length;
        var baseLetterList = new int[26];
        var currentLetterList = new int[26];
        
        foreach(var c in p) {
            baseLetterList[c - 'a']++;
        }
        
        for(int i = 0; i < p.Length; i++) {
            counter = GetNewCounter(baseLetterList, currentLetterList, counter, s[i]);
        }
        
        for(int i = 0; i <= s.Length - p.Length; i++) {
            if (counter == 0) {
                result.Add(i);
            }
            
            if (i + p.Length < s.Length) {
                counter = GetNewCounter(baseLetterList, currentLetterList, counter, s[i+p.Length]);
                counter = GetAddedCounter(baseLetterList, currentLetterList, counter, s[i]);
            }            
        }
        
        return result;
    }
    
    private int GetNewCounter(int[] baseLetterList, int[] currentLetterList, int counter, char c) {
        int index = c - 'a';
        currentLetterList[index]--;
        
        if (currentLetterList[index] >= 0 && currentLetterList[index] < baseLetterList[index]) {
            counter--;
        }
        
        return counter;
    }
    
    private int GetAddedCounter(int[] baseLetterList, int[] currentLetterList, int counter, char c) {
        int index = c - 'a';
        currentLetterList[index]++;
        
        if (currentLetterList[index] > 0 && currentLetterList[index] <= baseLetterList[index]) {
            counter++;
        }
        
        return counter;
    }
}
