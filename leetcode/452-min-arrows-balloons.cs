public class Solution
{
    public int FindMinArrowShots(int[,] points)
    {
        if (points == null || points.GetLength(0) == 0)
        {
            return 0;
        }

        var list = new List<int[]>();
        for (int i = 0; i < points.GetLength(0); i++)
        {
            list.Add(new int[] { points[i, 0], points[i, 1] });
        }

        var array = list.ToArray();
        Array.Sort<int[]>(array, new BalloonComparer());

        int arrowCount = 1;
        int arrowLimit = array[0][1];

        for (int i = 1; i < array.Length; i++)
        {
            var balloon = array[i];

            if (balloon[0] <= arrowLimit)
            {
                arrowLimit = Math.Min(arrowLimit, balloon[1]);
            }
            else
            {
                arrowCount++;
                arrowLimit = balloon[1];
            }
        }

        return arrowCount;
    }

    public class BalloonComparer : IComparer<int[]>
    {
        public int Compare(int[] b1, int[] b2)
        {
            if (b1[0] != b2[0])
            {
                return b1[0] - b2[0];
            }
            else
            {
                return b1[1] - b2[1];
            }
        }
    }
}
