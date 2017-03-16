public class Solution {
    public int MaxSubArrayLen(int[] nums, int k) {
        int maxSize = 0;
        if (nums == null || nums.Length == 0) {
            return maxSize;
        }

        var sumMap = new Dictionary<int, int>();
        sumMap[0] = -1;
        var sum = 0;
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
            var expectedSum = sum - k;

            // found a match, calculate the size
            if (sumMap.ContainsKey(expectedSum)) {
                maxSize = Math.Max(maxSize, i - sumMap[expectedSum]);
            }

            // add sum data to dictionary if not exists
            if (!sumMap.ContainsKey(sum)) {
                sumMap.Add(sum, i);
            }
        }

        return maxSize;
    }
}

    [TestClass]
    public class UnitTest1 {

        private Solution s = new Solution();

        [TestMethod]
        public void NullArrayTest() {
            var result = s.MaxSubArrayLen(null, 2);
            result.ShouldBeEquivalentTo(0);
        }

        [TestMethod]
        public void EmptyArrayTest() {
            var result = s.MaxSubArrayLen(new int[] { }, 2);
            result.ShouldBeEquivalentTo(0);
        }

        [TestMethod]
        public void SingleArrayMatchTest() {
            var result = s.MaxSubArrayLen(new int[] { 2 }, 2);
            result.ShouldBeEquivalentTo(1);
        }

        [TestMethod]
        public void SingleArrayMismatchTest() {
            var result = s.MaxSubArrayLen(new int[] { 3 }, 2);
            result.ShouldBeEquivalentTo(0);
        }

        [TestMethod]
        public void Match1() {
            var result = s.MaxSubArrayLen(new int[] { 1, 2, 3, 4 }, 6);
            result.ShouldBeEquivalentTo(3);
        }

        [TestMethod]
        public void Match2() {
            var result = s.MaxSubArrayLen(new int[] { 6, 1, 3, -2, 2, 5 }, 4);
            result.ShouldBeEquivalentTo(4);
        }

        [TestMethod]
        public void Match3() {
            var result = s.MaxSubArrayLen(new int[] { -1, 1, 2, -2, 3, -3, 4 }, 4);
            result.ShouldBeEquivalentTo(7);
        }

        [TestMethod]
        public void Mismatch() {
            var result = s.MaxSubArrayLen(new int[] { 1, 2, 3, 4 }, 20);
            result.ShouldBeEquivalentTo(0);
        }
    }
