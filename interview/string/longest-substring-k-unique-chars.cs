public class Solution {
    public string FineLongestSubstring(string str, int k) {
        var result = string.Empty;
        if (str == null || str.Length == 0 || k <= 0 || str.Length < k) {
            return result;
        }

        int counter = 1;
        int start = 0;
        int end = 0;
        var charMap = new int[26];
        charMap[str[0] - 'a'] = 1;

        while (end < str.Length && start <= end) {
            bool moveStart = false;
            bool moveEnd = false;

            // found result so we need to 
            if (counter == k) {
                result = end - start + 1 > result.Length ? str.Substring(start, end - start + 1) : result;
                moveEnd = true;
            }
            else if (counter < k) {
                moveEnd = true;
            }
            else {
                moveStart = true;
            }

            if (moveStart) {
                start++;
                if (start <= end) {
                    charMap[str[start - 1] - 'a'] -= 1;
                    counter = charMap[str[start - 1] - 'a'] == 0 ? counter - 1 : counter;
                }
            }

            if (moveEnd) {
                end++;
                if (end < str.Length) {
                    charMap[str[end] - 'a'] += 1;
                    counter = charMap[str[end] - 'a'] == 1 ? counter + 1 : counter;
                }
            }
        }

        return result;
    }
}


[TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void NullStringTest() {
            var s = new Solution();
            var result = s.FineLongestSubstring(null, 1);
            result.ShouldBeEquivalentTo(string.Empty);
        }

        [TestMethod]
        public void EmptyStringTest() {
            var s = new Solution();
            var result = s.FineLongestSubstring(string.Empty, 1);
            result.ShouldBeEquivalentTo(string.Empty);
        }

        [TestMethod]
        public void ZeroUniqueCharTest() {
            var s = new Solution();
            var result = s.FineLongestSubstring("ab", 0);
            result.ShouldBeEquivalentTo(string.Empty);
        }

        [TestMethod]
        public void OneUniqueCharTest() {
            var s = new Solution();
            var result = s.FineLongestSubstring("ab", 1);
            result.ShouldBeEquivalentTo("a");
        }

        [TestMethod]
        public void OneUniqueCharRepeatedStringTest() {
            var s = new Solution();
            var result = s.FineLongestSubstring("abaaab", 1);
            result.ShouldBeEquivalentTo("aaa");
        }

        [TestMethod]
        public void AllUniqueStringTest() {
            var s = new Solution();
            var result = s.FineLongestSubstring("ab", 2);
            result.ShouldBeEquivalentTo("ab");
        }

        [TestMethod]
        public void InvalidKTest() {
            var s = new Solution();
            var result = s.FineLongestSubstring("ab", 3);
            result.ShouldBeEquivalentTo(string.Empty);
        }

        [TestMethod]
        public void OtherTests() {
            var s = new Solution();
            var result = s.FineLongestSubstring("aabbccdd", 1);
            result.ShouldBeEquivalentTo("aa");

            result = s.FineLongestSubstring("aabbccdd", 2);
            result.ShouldBeEquivalentTo("aabb");

            result = s.FineLongestSubstring("aabbccdd", 3);
            result.ShouldBeEquivalentTo("aabbcc");

            result = s.FineLongestSubstring("aabbccdd", 4);
            result.ShouldBeEquivalentTo("aabbccdd");
        }
    }
