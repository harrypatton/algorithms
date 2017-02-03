public class Solution {
    public bool CanIWin(int maxChoosableInteger, int desiredTotal) {
        // check edge cases: maxChoosableInteger <= 0
        if (maxChoosableInteger <= 0) {
            return false;
        }
        
        // check edge cases: desiredTotal > sum of all integers
        int sum = maxChoosableInteger * (maxChoosableInteger + 1) / 2;
        if (sum < desiredTotal) {
            return false;
        }
        
        // win if desired total <= 0
        if (desiredTotal <= 0) {
            return true;
        }

        var result = new Dictionary<int, bool>();
        var intUsageList = new bool[maxChoosableInteger];
        return CanIWin(result, intUsageList, desiredTotal);
    }
    
    private bool CanIWin(IDictionary<int, bool> cache, bool[] intUsageList, int desiredTotal) {
        // already reached the desired total so this one failed.
        if (desiredTotal <= 0) {
            return false;
        }
        
        int key = ConvertToInt(intUsageList);
        if (cache.ContainsKey(key)) {
            return cache[key];
        }        
        
        bool result = false;
        
        for(int i = 0; i < intUsageList.Length; i++) {
            if (intUsageList[i] == false) {
                
                intUsageList[i] = true;                
                bool canWin = CanIWin(cache, intUsageList, desiredTotal - (i + 1));
                intUsageList[i] = false;                
                
                if (!canWin){
                    result = true;
                    break;
                }
            }
        }
        
        // update cache
        cache.Add(key, result);
        
        return result;
    }
    
    private int ConvertToInt(bool[] array) {
        int result = 0;
        
        foreach(var value in array) {
            result = (result << 1) + (value ? 1 : 0);
        }
        
        return result;
    }
}
