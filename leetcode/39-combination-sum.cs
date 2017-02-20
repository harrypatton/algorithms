    public class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            return CombinationSum(candidates, 0, target);
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int startIndex, int target)
        {
            var result = new List<IList<int>>();
            if (candidates == null || startIndex > candidates.Length - 1 || target < 0)
            {
                return result;
            }

            // current element is the candidate
            if (target == candidates[startIndex])
            {
                result.Add(new List<int>(new int[] { candidates[startIndex] }));
            }

            // results excluding first element
            result.AddRange(CombinationSum(candidates, startIndex + 1, target));

            // result including first element
            var subResult = CombinationSum(candidates, startIndex + 1, target - candidates[startIndex]);
            foreach (var list in subResult)
            {
                list.Insert(0, candidates[startIndex]);
            }

            result.AddRange(subResult);

            return result;
        }
    }
