public class Solution {
    public string FrequencySort(string s) {
        if (s == null || s.Length <= 1) {
            return s;
        }
        
        var freqList = new Dictionary<char, int>();
        foreach(char c in s) {
            freqList[c] = freqList.ContainsKey(c) ? freqList[c] + 1 : 1;
        }
        
        var freqListOrderByDesc = freqList.OrderByDescending(pair => pair.Value);
        var result = new char[s.Length];
        var index = 0;
        
        foreach(var pair in freqListOrderByDesc) {
            for(int i = 0; i < pair.Value; i++) {
                result[index++] = pair.Key;
            }
        }
        
        return new string(result);
    }
}
