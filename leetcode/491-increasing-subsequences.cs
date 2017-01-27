public class Solution
{
    public IList<IList<int>> FindSubsequences(int[] nums)
    {
        return FindSubsequences(nums, nums.Length - 1);
    }

    public IList<IList<int>> FindSubsequences(int[] nums, int endIndex)
    {
        // check parameters
        if (nums == null || !nums.Any() || endIndex <= 0)
        {
            return new List<IList<int>>();
        }

        var subResult = FindSubsequences(nums, endIndex - 1);
        var currentElement = nums[endIndex];

        var result = new List<IList<int>>();

        // add 2-element sub-array result
        for (int i = 0; i < endIndex; i++)
        {
            if (nums[i] <= nums[endIndex])
            {
                result.Add(new List<int>(new int[] { nums[i], nums[endIndex] }));
            }
        }

        // add previous subresult
        result.AddRange(subResult);

        // add new increasing subsequence based on subresult
        foreach (var subList in subResult)
        {
            if (subList.Last() <= currentElement)
            {
                var newList = new List<int>(subList);
                newList.Add(currentElement);
                result.Add(newList);
            }
        }

        // eliminate duplicate results
        var listComparer = new ListComparer();
        result = result.Distinct(listComparer).ToList();

        return result;
    }

    public class ListComparer : IEqualityComparer<IList<int>>
    {
        public bool Equals(IList<int> x, IList<int> y)
        {
            if (x.Count == y.Count)
            {
                for(int i = 0; i < x.Count; i++)
                {
                    if (x[i] != y[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public int GetHashCode(IList<int> obj)
        {
            int hashValue = 1;

            foreach(var value in obj)
            {
                hashValue = hashValue * 17 + value;
            }

            return hashValue;
        }
    }
}
