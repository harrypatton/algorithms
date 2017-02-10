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
		
		var result = OriginalDigits(charCount, numUsed);
		
		char[] resultChar = result.ToArray();
		Array.Sort(resultChar);
		return new string(resultChar);
    }
	
	public string OriginalDigits(int[] charCount, bool[] numUsed) {
		var result = string.Empty;
		
		for(int i = 0; i < charCount.Length; i++) {
			if (charCount[i] < 0) {
				return result;
			}
		}
		
		for(int i = 0; i < numUsed.Length; i++) {
			if(!numUsed[i]) {
				// we'll try this number so two conditions
				
				// set flag
				numUsed[i] = true;
				
				// condition #1 - the result has this number
				RemoveCharCount(charCount, i);
				string tempResult = OriginalDigits(charCount, numUsed);
				
				if (tempResult != string.Empty) {
					result += tempResult + i;
				}
				
				// condition #2 - the result doesn't have this number
				
				// restore chars first
				AddCharCount(charCount, i);
				tempResult = OriginalDigits(charCount, numUsed);
				
				if (tempResult != string.Empty) {
					result += tempResult;
				}
				
				// restore
				numUsed[i] = false;
			}
		}
		
		return result;
	}
	
	public void AddCharCount(int[] charCount, int number) {
		foreach(var c in numStrings[number]) {
			charCount[c - 'a']++;
		}
	}
	
	public void RemoveCharCount(int[] charCount, int number) {
		foreach(var c in numStrings[number]) {
			charCount[c - 'a']--;
		}
	}
	
	string[] numStrings = new string[] {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
}
	
