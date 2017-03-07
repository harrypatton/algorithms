public class Solution {
    public bool HasOverlap(int[][] pairs) {
        if (pairs == null || pairs.Length < 2) {
            return false;
        }

        Array.Sort(pairs, (pair1, pair2) => pair1[0] - pair2[0]);

        for (int i = 1; i < pairs.Length; i++) {
            if (pairs[i - 1][1] > pairs[i][0]) {
                return true;
            }
        }

        return false;
    }
}

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void NullTest() {
            var s = new Solution();
            s.HasOverlap(null).Should().BeFalse();
        }

        [TestMethod]
        public void SinglePairTest() {
            var s = new Solution();
            s.HasOverlap(new int[][] {
                new int[] { 1, 2 },
            }).Should().BeFalse();
        }

        [TestMethod]
        public void TwoNonOverlapPairsTest() {
            var s = new Solution();
            s.HasOverlap(new int[][] {
                new int[] { 1, 2 },
                new int[] { 3, 4 },
            }).Should().BeFalse();
        }

        [TestMethod]
        public void TwoOverlapPairsTest() {
            var s = new Solution();
            s.HasOverlap(new int[][] {
                new int[] { 1, 3 },
                new int[] { 2, 4 },
            }).Should().BeTrue();
        }

        [TestMethod]
        public void TwoEmbracedPairsTest() {
            var s = new Solution();
            s.HasOverlap(new int[][] {
                new int[] { 1, 6 },
                new int[] { 2, 4 },
            }).Should().BeTrue();
        }

        [TestMethod]
        public void MultiOverlapPairsTest() {
            var s = new Solution();
            s.HasOverlap(new int[][] {
                new int[] { 1, 3 },
                new int[] { 2, 4 },
                new int[] { 3, 6 },
            }).Should().BeTrue();
        }

        [TestMethod]
        public void MultiNonOverlapPairsTest() {
            var s = new Solution();
            s.HasOverlap(new int[][] {
                new int[] { 7, 8 },
                new int[] { 1, 2 },
                new int[] { 5, 6 },
            }).Should().BeFalse();
        }
    }
}
