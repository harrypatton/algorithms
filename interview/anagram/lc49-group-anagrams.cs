public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var result = new Dictionary<string, IList<string>>();
        if (strs == null || strs.Length == 0) {
            return result.Values.ToList();
        }
        
        foreach(var str in strs) {
            var key = GetKey(str);            
            if (!result.ContainsKey(key)) {
                result[key] = new List<string>();
            }
            
            result[key].Add(str);
        }
        
        return result.Values.ToList();
    }
    
    private string GetKey(string str){
        var counter = new int[26];
        foreach(char c in str) {
            counter[c-'a']++;
        }
        
        var key = new StringBuilder();
        foreach(int count in counter){
            key.Append(count.ToString() + ",");
        }
        
        return key.ToString();
    }
}
