using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


public class Solution {
    public IList<int[]> GetPermutation(IList<int[]> list) {
        var result = new List<IList<int>>();
        result.Add(new List<int>());

        for(int i = 0; i < list.Count; i++) {
            int count = result.Count;

            // sort the array
            var array = list[i];
            Array.Sort(array);

            // add the unique char to every list in the result
            for (int j = 0; j < array.Length; j++) {
                // exclude duplicate chars
                if (j == 0 || array[j] != array[j - 1]) {
                    for(int k = 0; k < count; k++) {
                        var tempList = new List<int>(result[k]);
                        tempList.Add(array[j]);
                        result.Add(tempList);
                    }
                }
            }

            // discard previous result
            for(int j = 0; j < count; j++) {
                result.RemoveAt(0);
            }
        }

        return result.Select(item => item.ToArray()).ToList();
    }

    public static void MainScenarioTest() {
        var s = new Solution();

        IList<int[]> testList = new List<int[]>();
        testList.Add(new int[] { 1, 2, 3 });
        testList.Add(new int[] { 4 });
        testList.Add(new int[] { 5, 6 });

        Print(testList.Select(item => item.AsEnumerable<int>()));

        var result = s.GetPermutation(testList);
        Print(result);
    }

    public static void SingleElementArrays() {
        var s = new Solution();

        IList<int[]> testList = new List<int[]>();
        testList.Add(new int[] { 1 });
        testList.Add(new int[] { 4 });
        testList.Add(new int[] { 5 });

        Print(testList.Select(item => item.AsEnumerable<int>()));

        var result = s.GetPermutation(testList);
        Print(result);
    }

    public static void ArrayWithDupeElements() {
        var s = new Solution();

        IList<int[]> testList = new List<int[]>();
        testList.Add(new int[] { 1, 2, 3 });
        testList.Add(new int[] { 4, 4 });
        testList.Add(new int[] { 5, 6, 6 });

        Print(testList.Select(item => item.AsEnumerable<int>()));

        var result = s.GetPermutation(testList);
        Print(result);
    }

    public static void SingleArray() {
        var s = new Solution();

        IList<int[]> testList = new List<int[]>();
        testList.Add(new int[] { 1, 2, 3 });

        Print(testList.Select(item => item.AsEnumerable<int>()));

        var result = s.GetPermutation(testList);
        Print(result);
    }

    public static void SingleArraySingleElement() {
        var s = new Solution();

        IList<int[]> testList = new List<int[]>();
        testList.Add(new int[] { 1 });

        Print(testList.Select(item => item.AsEnumerable<int>()));

        var result = s.GetPermutation(testList);
        Print(result);
    }

    public static void EmptyArray() {
        var s = new Solution();

        IList<int[]> testList = new List<int[]>();
        Print(testList.Select(item => item.AsEnumerable<int>()));

        var result = s.GetPermutation(testList);
        Print(result);
    }

    public static void Print(IEnumerable<IEnumerable<int>> list) {
        var listStrings = list.Select(item => $"[{string.Join(",", item.Select(num => num.ToString()))}]");
        Console.WriteLine(string.Join(",", listStrings));
    }
}
