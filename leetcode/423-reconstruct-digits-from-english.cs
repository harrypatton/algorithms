public class Solution {
    public string OriginalDigits(string s) {
        if (s == null || s == string.Empty) {
			return string.Empty;
		}
		
		int[] charCount = new int[26];
		bool[] numUsed = new bool[10];
		
		foreach(var c in s) {
			charCount[c - 'a']++;
		}
		
		return OriginalDigits(charCount, numUsed);
    }
	
	public string OriginalDigits(int[] charCount, bool[] numUsed) {
		var result = string.Empty;
		
		for(int i = 0; i < charCount; i++) {
			if (charCount[i] < 0) {
				return result;
			}
		}
		
		for(int i = 0; i < numUsed; i++) {
			if(!numUsed[i]) {
				// we'll try this number so two conditions
				
				// set flag
				numUsed[i] = true;
				
				// condition #1 - the result has this number
				RemoveCharCount(charCount, numUsed[i]);
				string tempResult = OriginalDigits(charCount, numUsed);
				
				if (tempResult != string.Empty) {
					result += tempResult + i;
				}
				
				// condition #2 - the result doesn't have this number
				
				// restore chars first
				AddCharCount(charCount, numUsed[i]);
				tempResult = OriginalDigits(charCount, numUsed);
				
				if (tempResult != string.Empty) {
					result += tempResult;
				}
				
				// restore
				numUsed[i] = false;
			}
		}
		
		return result.Sort();
	}
	
	public void AddCharCount(int[] charCount, int number) {
		foreach(var c in numStrings[number]) {
			charCount[c - 'a']++;
		}
	}
	
	public bool RemoveCharCount(int[] charCount, int number) {
		foreach(var c in numStrings[number]) {
			charCount[c - 'a']--;
		}
	}
	
	string[] numStrings = new string[] {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
}
	
