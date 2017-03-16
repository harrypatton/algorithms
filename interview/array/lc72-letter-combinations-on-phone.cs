public class Solution {
    public IList<string> LetterCombinations(string digits) {
        var result = new Queue<string>();

        // edge cases
        if (digits == null || digits.Length == 0) {
            return result.ToList();
        }

        // base
        result.Enqueue(string.Empty);

        // check every letter
        foreach (var c in digits) {
            // validate digits.

            int number = c - '0';
            int startChar = 'a' + 3 * (number - 2) + (number >= 8 ? 1 : 0);
            int endChar = startChar + (number == 7 || number == 9 ? 3 : 2);

            int queueCount = result.Count;
            for (int i = 0; i < queueCount; i++) {
                var tempString = result.Dequeue();

                // calculate the candidates.
                for (int letter = startChar; letter <= endChar; letter++) {
                    result.Enqueue(tempString + ((char)letter).ToString());
                }
            }
        }

        return result.ToList();
    }
}
