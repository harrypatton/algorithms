public class Solution
{
    public IList<string> ReadBinaryWatch(int num)
    {
        // hour: no leading zero
        // minute: 2 digit, so it can have leading zero.

        var result = new List<string>();

        for (int i = 0; i <= num; i++)
        {
            if (i >= 0 && i <= 4 && (num - i) >= 0 && (num - i) <= 6)
            {
                result.AddRange(ReadBinaryWatch(i, num - i));
            }
        }

        return result;
    }

    private IList<string> ReadBinaryWatch(int hourNum, int minuteNum)
    {
        var result = new List<string>();
        var hourString = Calculate(4, hourNum);
        var minuteString = Calculate(6, minuteNum);

        foreach (int hour in hourString)
        {
            foreach (int minute in minuteString)
            {
                if (hour < 12 && minute < 60)
                {
                    var time = string.Format("{0}:{1}", hour, (minute > 9 ? string.Empty : "0") + minute.ToString());
                    result.Add(time);
                }                
            }
        }

        return result;
    }

    private IList<int> Calculate(int count, int num)
    {
        var result = new List<int>();

        if (num == 0)
        {
            result.Add(0);
        }
        else if (num == count)
        {
            result.Add((1 << num) - 1);
        }
        else
        {
            var tempResult = this.Calculate(count - 1, num);
            foreach (var value in tempResult)
            {
                result.Add((value << 1));
            }

            tempResult = this.Calculate(count - 1, num - 1);
            foreach (var value in tempResult)
            {
                result.Add((value << 1) + 1);
            }
        }

        return result;
    }
}
