public class Solution
        {
            public int FindMaxForm(string[] strs, int m, int n)
            {
                if (strs == null || !strs.Any() || m < 0 || n < 0 || (m == 0 && n == 0))
                {
                    return 0;
                }

                var subResults = new int[(m + 1) * (n + 1)];

                for (int array_index = 0; array_index < strs.Length; array_index++)
                {
                    var newSubResults = new int[(m + 1) * (n + 1)];

                    // calculate '1' count and '0' count.
                    int oneCount = 0;
                    int zeroCount = 0;

                    foreach (var c in strs[array_index])
                    {
                        if (c == '1')
                        {
                            oneCount++;
                        }
                        else
                        {
                            zeroCount++;
                        }
                    }

                    for (int i = 0; i <= m; i++)
                    {
                        for (int j = 0; j <= n; j++)
                        {
                            int result_index = i * (n+1) + j;

                            // exclude current element, choose the result from previous column with the same row.
                            // i.e., current cache (which hasn't bee updated yet).
                            int result1 = subResults[result_index];

                            // include current element, then we need to calculate new index.
                            int index_i = i - zeroCount;
                            int index_j = j - oneCount;

                            int result2 = 0;

                            if (index_i >= 0 && index_j >= 0)
                            {
                                int hop_result_index = index_i * (n+1) + index_j;
                                result2 = subResults[hop_result_index] + 1;
                            }

                            // update current result
                            newSubResults[result_index] = Math.Max(result1, result2);
                        }
                    }

                    subResults = newSubResults;
                }

                return subResults[subResults.Length - 1];
            }
        }
