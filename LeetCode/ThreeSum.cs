using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        int[] sorted = (from n in nums orderby n ascending select n).ToArray();
        HashSet<int> visited = new HashSet<int>();
        List<IList<int>> list = new List<IList<int>>();
        //Console.WriteLine("Here");
        for(int i = 0; i < sorted.Length; i++)
        {
            if (visited.Contains(sorted[i]))
            {
                continue;
            }
            visited.Add(sorted[i]);
            int j = i + 1;
            int k = sorted.Length - 1;
            HashSet<(int,int)> visited2 = new HashSet<(int,int)>();
            while (j < k)
            {
                //Console.WriteLine($"{sorted[i]}, {sorted[j]}, {sorted[k]}");
                int sum2 = sorted[j] + sorted[k];
                if (sum2 == -sorted[i])
                {
                    if (!visited2.Contains((sorted[j], sorted[k])))
                    {
                        list.Add(new List<int>() { sorted[i], sorted[j], sorted[k] });
                        visited2.Add((sorted[j], sorted[k]));
                    }
                    k--;
                    j++;
                } else if(sum2 > -sorted[i])
                {
                    k--;
                } else
                {
                    j++;
                }
            }
        }
        return list;
    }
}


//public class Solution
//{
//    public IList<IList<int>> ThreeSum(int[] nums)
//    {
//        int[,] matrtix = new int[nums.Length, nums.Length];
//        Dictionary<int, (int, int)> dict = new Dictionary<int, (int, int)>();
//        List<IList<int>> list = new List<IList<int>>();
//        for (int i = 0; i < nums.Length; i++)
//        {
//            if (dict.ContainsKey(nums[i]))
//            {
//                list.Add(new List<int>() { nums[i], nums[dict[nums[i]].Item1], nums[dict[nums[i]].Item2] });
//            }
//            for (int j = 0; j < i; j++)
//            {
//                dict[-(nums[i] + nums[j])] = (i, j);
//                Console.WriteLine($"Adding: key: {nums[i] + nums[j]} Values: {i}, {j}");
//            }
//        }
//        return list;
//    }
//}