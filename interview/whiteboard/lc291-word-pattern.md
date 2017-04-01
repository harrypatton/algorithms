[Source](https://discuss.leetcode.com/topic/26750/share-my-java-backtracking-solution)

Question: Given a pattern and a string, check whether the string matches the pattern. 
For example: pattern "aba" and the string is "redblackred" then it matches 
because "a" is translated to red and "b" is translated to "black". 
Note that for each character in the pattern, the translation is non-empty and unique.

## Analysis
It is easier to come up with backtracking. The difficult thing is to calculate the O(n).

```csharp
public class Solution {
    public bool IsMatch(string p, string s) {
        if (p == null && s == null) return true;
        if (p == null || s == null) return false;

        var dict = new Dictionary<char, string>();
        var value = new HashSet<string>();
        return IsMatch(p, 0, s, 0, dict, value);
    }

    public bool IsMatch(string p, int index1, string s, int index2, Dictionary<char, string> dict, HashSet<string> value) {
        if (index1 == p.Length && index2 == s.Length) return true;
        if (index1 >= p.Length || index2 >= s.Length) return false;

        var key = p[index1];
        if (dict.ContainsKey(key)) { // if the hash table has the matching
            int index = s.IndexOf(dict[key], index2);
            if (index != index2) { // return false when the string doesn't match this char.
                return false;
            } else { // continue to match the rest
                return IsMatch(p, index1 + 1, s, index2 + dict[key].Length, dict, value);
            }
        } else {
            // try every possible substring for current char.
            for(int i = index2; i < s.Length; i++) {
                string newString = s.Substring(index2, i - index2 + 1);

                if (value.Contains(newString)) {
                    continue;
                }

                dict[key] = newString;
                value.Add(newString);

                if (IsMatch(p, index1 + 1, s, index2 + newString.Length, dict, value)) {
                    return true;
                } else {
                    dict.Remove(key);
                    value.Remove(newString);
                }
            }
        }

        return false;
    }
}
```

```csharp
public class UnitTest1 {

        private Solution s = new Solution();

        [TestMethod]
        public void Test1() {
            var result = s.IsMatch("aba", "redblackred");
            result.Should().BeTrue();
        }

        [TestMethod]
        public void Test2() {
            var result = s.IsMatch(null, null);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void Test3() {
            var result = s.IsMatch("aba", null);
            result.Should().BeFalse();
        }

        [TestMethod]
        public void Test4() {
            var result = s.IsMatch("", "");
            result.Should().BeTrue();
        }

        [TestMethod]
        public void Test5() {
            var result = s.IsMatch("", "redblackred");
            result.Should().BeFalse();
        }

        [TestMethod]
        public void Test6() {
            var result = s.IsMatch("aba", "");
            result.Should().BeFalse();
        }

        [TestMethod]
        public void Test7() {
            var result = s.IsMatch("abc", "redblackred");
            result.Should().BeTrue();
        }

        [TestMethod]
        public void Test8() {
            var result = s.IsMatch("abc", "redblackblue");
            result.Should().BeTrue();
        }

        [TestMethod]
        public void Test9() {
            var result = s.IsMatch("a", "black");
            result.Should().BeTrue();
        }

        [TestMethod]
        public void Test10() {
            var result = s.IsMatch("ab", "ab");
            result.Should().BeTrue();
        }

        [TestMethod]
        public void Test11() {
            var result = s.IsMatch("ab", "helloworld");
            result.Should().BeTrue();
        }

        [TestMethod]
        public void Test12() {
            var result = s.IsMatch("abb", "helloworldworld");
            result.Should().BeTrue();
        }

        [TestMethod]
        public void Test13() {
            var result = s.IsMatch("ab", "aa");
            result.Should().BeFalse();
        }

        [TestMethod]
        public void Test14() {
            var result = s.IsMatch("abcba", "aabbccddee");
            result.Should().BeFalse();
        }

        [TestMethod]
        public void Test15() {
            var result = s.IsMatch("abc", "ded");
            result.Should().BeFalse();
        }

        [TestMethod]
        public void Test16() {
            var result = s.IsMatch("aa", "aa");
            result.Should().BeTrue();
        }
    }
```
