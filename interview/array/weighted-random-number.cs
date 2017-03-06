    public class Solution {

        private Random r = new Random();

        public int GetRandomNumber(int[,] nums) { 
            if (nums == null || nums.Length == 0) {
                throw new ArgumentException();
            }

            int weightSum = 0;

            // btw, I don't like the 2d matrix because of this. 
            // I have to use some space for binary search later.
            var sumArray = new int[nums.GetLength(0)];
            for(int i = 0; i < nums.GetLength(0); i++) {
                weightSum += nums[i, 1];
                sumArray[i] = weightSum;
            }

            // binary search
            var targetWeightSum = r.Next(1, weightSum + 1);
            int index = Array.BinarySearch(sumArray, 0, sumArray.Length, targetWeightSum);
            
            if (index < 0) {
                index = ~index;
            }

            return nums[index, 0];
        }
    }
